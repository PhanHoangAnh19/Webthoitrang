using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebBanDoThoiTrang.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Bắt buộc nhập tên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập Pass")]
        [StringLength(40,MinimumLength =8, ErrorMessage ="Mat khau {0} phải có ít nhất {2} kí tự và dài nhất {1} kí tự")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage ="mật khẩu không trùng khớp.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập ConfilmPass")]
        [DataType(DataType.Password)]
        [Display(Name = "Confilm Password")]
        public string ConfirmPassword { get; set; }
    }
}
