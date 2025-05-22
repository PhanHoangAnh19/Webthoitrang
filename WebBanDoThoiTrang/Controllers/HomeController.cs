using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebBanDoThoiTrang.Models;

namespace WebBanDoThoiTrang.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult INNEW()
        {
            return View();
        }
        public IActionResult SANPHAM()
        {
            return View();
        }
        public IActionResult LOOKBOOK()
        {
            return View();
        }
        public IActionResult DIPVASUKIEN()
        {
            return View();
        }
        public IActionResult BLOG()
        {
            return View();
        }
        public IActionResult CUAHANG()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
