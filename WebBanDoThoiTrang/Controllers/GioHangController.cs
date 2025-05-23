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

            var cart = HttpContext.Session.GetObject<List<GioHang>>(CART_KEY)
                       ?? new List<GioHang>();

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

            HttpContext.Session.SetObject(CART_KEY, cart);
            return RedirectToAction(nameof(ThemVaoGioHang));
        }

        // GET: /GioHang/ThemVaoGioHang
        [HttpGet]
        public IActionResult ThemVaoGioHang()
        {
            var cart = HttpContext.Session.GetObject<List<GioHang>>(CART_KEY)
                       ?? new List<GioHang>();
            return View(cart);
        }

        // POST: /GioHang/CapNhat
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CapNhat(int productId, int quantity)
        {
            var cart = HttpContext.Session.GetObject<List<GioHang>>(CART_KEY)
                       ?? new List<GioHang>();
            var item = cart.FirstOrDefault(c => c.MaSanPham == productId);
            if (item != null)
            {
                item.Quantity = quantity < 1 ? 1 : quantity;
                HttpContext.Session.SetObject(CART_KEY, cart);
            }
            return RedirectToAction(nameof(ThemVaoGioHang));
        }

        // POST: /GioHang/Xoa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Xoa(int productId)
        {
            var cart = HttpContext.Session.GetObject<List<GioHang>>(CART_KEY)
                       ?? new List<GioHang>();
            var item = cart.FirstOrDefault(c => c.MaSanPham == productId);
            if (item != null)
            {
                cart.Remove(item);
                HttpContext.Session.SetObject(CART_KEY, cart);
            }
            return RedirectToAction(nameof(ThemVaoGioHang));
        }
    }
}
