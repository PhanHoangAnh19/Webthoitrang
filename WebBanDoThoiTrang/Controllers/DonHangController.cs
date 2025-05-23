using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebBanDoThoiTrang.Data;
using WebBanDoThoiTrang.Models;
using WebBanDoThoiTrang.Services;

namespace WebBanDoThoiTrang.Controllers
{
    public class DonHangController : Controller
    {
        private readonly AppDbcontext _db;
        private readonly ICartService _cartSvc;
        private readonly UserManager<Users> _userManager;

        public DonHangController(
            AppDbcontext db,
            ICartService cartSvc,
            UserManager<Users> userManager)
        {
            _db = db;
            _cartSvc = cartSvc;
            _userManager = userManager;
        }

        


        // POST /DonHang/ThanhToanConfirmed
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ThanhToanConfirmed()
        {
            var cart = _cartSvc.GetCart();
            if (!cart.Items.Any())
                return RedirectToAction("DanhSachSanPham", "SanPham");

            // 1) Lấy user Identity
            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null)
                return Challenge();    // yêu cầu login

            // 2) Tìm KhachHang theo email
            var kh = await _db.KhachHangs
                              .FirstOrDefaultAsync(x => x.Email == identityUser.Email);
            if (kh == null)
                return BadRequest("Không tìm thấy thông tin khách hàng.");

            // 3) Tạo đơn hàng mới
            var dh = new DonHang
            {
                MaKhachHang = kh.MaKhachHang,
                NgayDatHang = DateTime.Now,
                TongTien = cart.Total,
                ChiTietDonHangs = cart.Items
                    .Select(i => new ChiTietDonHang
                    {
                        SanPhamId = i.MaSanPham,
                        SoLuong = i.Quantity,
                        DonGia = i.DonGia
                    })
                    .ToList()
            };

            _db.DonHangs.Add(dh);
            await _db.SaveChangesAsync();

            // 4) Clear giỏ
            _cartSvc.Clear();

            // 5) Redirect tới trang xác nhận
            return RedirectToAction("XacNhan", new { id = dh.MaDonHang });
        }

        // GET /DonHang/XacNhan/5
        [HttpGet]
        public async Task<IActionResult> XacNhan(int id)
        {
            var dh = await _db.DonHangs
                .Include(d => d.ChiTietDonHangs)
                   .ThenInclude(ct => ct.SanPham)
                .Include(d => d.KhachHang)
                .FirstOrDefaultAsync(d => d.MaDonHang == id);

            if (dh == null) return NotFound();
            return View(dh);
        }
    }
}
