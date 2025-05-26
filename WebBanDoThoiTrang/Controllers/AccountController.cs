using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebBanDoThoiTrang.Data;       
using WebBanDoThoiTrang.Models;    
using WebBanDoThoiTrang.ViewModels; 

namespace WebBanDoThoiTrang.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Users> _signInManager;
        private readonly UserManager<Users> _userManager;
        private readonly AppDbcontext _db;    

        public AccountController(SignInManager<Users> signInManager,UserManager<Users> userManager,AppDbcontext db)               
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _signInManager
                .PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Email hoặc mật khẩu không đúng!");
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

          
            var user = new Users
            {
                Fullname = model.Name,
                Email = model.Email,
                UserName = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                
                var kh = new KhachHang
                {
                    HoTen = model.Name,
                    Email = model.Email,
                    DienThoai = "",  
                    DiaChi = ""   
                };
                _db.KhachHangs.Add(kh);
                await _db.SaveChangesAsync();

                return RedirectToAction("Login", "Account");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);
            return View(model);
        }

        public IActionResult VerifyEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email không tồn tại!");
                return View(model);
            }

            return RedirectToAction(
                "ChangePassword",
                "Account",
                new { username = user.UserName }
            );
        }

        public IActionResult ChangePassword(string username)
        {
            if (string.IsNullOrEmpty(username))
                return RedirectToAction("VerifyEmail");

            return View(new ChangePassViewModel { Email = username });
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Có gì đó sai sai!");
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email không tồn tại!");
                return View(model);
            }

            var removeResult = await _userManager.RemovePasswordAsync(user);
            if (!removeResult.Succeeded)
            {
                foreach (var err in removeResult.Errors)
                    ModelState.AddModelError("", err.Description);
                return View(model);
            }

            var addResult = await _userManager.AddPasswordAsync(user, model.NewPassword);
            if (addResult.Succeeded)
                return RedirectToAction("Login");

            foreach (var err in addResult.Errors)
                ModelState.AddModelError("", err.Description);
            return View(model);
        }
    }
}
