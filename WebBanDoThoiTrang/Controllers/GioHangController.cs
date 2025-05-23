using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebBanDoThoiTrang.Data;
using WebBanDoThoiTrang.Helpers;
using WebBanDoThoiTrang.Models;

namespace WebBanDoThoiTrang.Controllers
{
    public class GioHangController : Controller
    {
        private readonly AppDbcontext _db;
        private const string CART_KEY = "CART_SESSION";

        public GioHangController(AppDbcontext db)
        {
            _db = db;
        }

        // POST: /GioHang/ThemVaoGioHang/5
        [HttpPost]
        public IActionResult ThemVaoGioHang(int id)
        {
            var sp = _db.SanPhams.Find(id);
            if (sp == null) return NotFound();

            // Lấy giỏ hàng từ Session (hoặc tạo mới)
            var cart = HttpContext.Session.GetObject<List<GioHang>>(CART_KEY)
                       ?? new List<GioHang>();

            // Kiểm tra tồn tại
            var item = cart.FirstOrDefault(c => c.MaSanPham == id);
            if (item == null)
            {
                cart.Add(new GioHang
                {
                    MaSanPham = sp.MaSanPham,
                    TenSanPham = sp.TenSanPham,
                    HinhAnh = sp.HinhAnh,
                    DonGia = sp.DonGia,
                    Quantity = 1
                });
            }
            else
            {
                item.Quantity++;
            }

            // Lưu lại Session
            HttpContext.Session.SetObject(CART_KEY, cart);

            // Chuyển sang GET để hiển thị giỏ hàng
            return RedirectToAction(nameof(ThemVaoGioHang));
        }

        // GET: /GioHang/ThemVaoGioHang
        [HttpGet]
        public IActionResult ThemVaoGioHang()
        {
            var cart = HttpContext.Session.GetObject<List<GioHang>>(CART_KEY)
                       ?? new List<GioHang>();
            return View(cart);    // sẽ render Views/GioHang/ThemVaoGioHang.cshtml
        }
    }
}
