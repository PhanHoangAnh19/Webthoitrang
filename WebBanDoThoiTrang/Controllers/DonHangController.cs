using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebBanDoThoiTrang.Data;
using WebBanDoThoiTrang.Models;
using WebBanDoThoiTrang.Services;
using WebBanDoThoiTrang.Helpers;  
using System.Collections.Generic;


namespace WebBanDoThoiTrang.Controllers
{
    public class DonHangController : Controller
    {
        private readonly AppDbcontext _db;
        private readonly UserManager<Users> _userManager;

        public DonHangController(AppDbcontext db,UserManager<Users> userManager)
        {
            _db = db;
            _userManager = userManager;
        }




        // POST /DonHang/ThanhToanConfirmed
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ThanhToanConfirmed()
        {
            const string CART_KEY = "CART_SESSION";

            // 1) Lấy giỏ từ session (List<GioHang>)
            var cart = HttpContext.Session.GetObject<List<GioHang>>(CART_KEY)
                       ?? new List<GioHang>();
            if (!cart.Any())
                return RedirectToAction("DanhSachSanPham", "SanPham");

            // 2) Lấy user Identity
            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null)
                return Challenge();

            // 3) Tìm Khách hàng
            var kh = await _db.KhachHangs
                              .FirstOrDefaultAsync(x => x.Email == identityUser.Email);
            if (kh == null)
                return BadRequest("Không tìm thấy thông tin khách hàng.");

            // 4) Tạo DonHang
            var dh = new DonHang
            {
                MaKhachHang = kh.MaKhachHang,
                NgayDatHang = DateTime.Now,
                TongTien = cart.Sum(i => i.DonGia * i.Quantity),
                ChiTietDonHangs = cart.Select(i => new ChiTietDonHang
                {
                    SanPhamId = i.MaSanPham,
                    SoLuong = i.Quantity,
                    DonGia = i.DonGia
                }).ToList()
            };
            _db.DonHangs.Add(dh);
            await _db.SaveChangesAsync();

            // 5) Xóa session giỏ hàng
            HttpContext.Session.Remove(CART_KEY);

            // 6) Chuyển sang xác nhận
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
