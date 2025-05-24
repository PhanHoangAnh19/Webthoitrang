using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebBanDoThoiTrang.Data;

namespace WebBanDoThoiTrang.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly AppDbcontext _db;
        public SanPhamController(AppDbcontext db)
        {
            _db = db;
        }

       
        public IActionResult DanhSachSanPham()
        {
            var list = _db.SanPhams.ToList();
            return View(list);  
        }

        public async Task<IActionResult> InNew()
        {
            var moiNhat = await _db.SanPhams
                               .OrderByDescending(s => s.MaSanPham)
                               .Take(8)
                               .ToListAsync();
            return View(moiNhat);
        }

        public async Task<IActionResult> TongSP()
        {
            var moiNhat = await _db.SanPhams
                               .OrderByDescending(s => s.MaSanPham)
                               .Take(8)
                               .ToListAsync();
            return View(moiNhat);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var sp = _db.SanPhams.FirstOrDefault(x => x.MaSanPham == id);
            if (sp == null)
            {
                return NotFound();
            }
            return View(sp);
        }
    }
}
