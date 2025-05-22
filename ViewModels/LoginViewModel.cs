using System.ComponentModel.DataAnnotations;

namespace WebBanDoThoiTrang.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Bắt buộc phải nhập Email!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bắt buộc phải nhập Pass!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }

    }
}
