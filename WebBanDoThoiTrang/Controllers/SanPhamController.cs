using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        // Đây là action phải return kèm model để view không null
        public IActionResult DanhSachSanPham()
        {
            var list = _db.SanPhams.ToList();
            return View(list);   // ← CHÚ Ý: phải truyền list vào
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
