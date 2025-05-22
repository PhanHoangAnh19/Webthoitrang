using System.ComponentModel.DataAnnotations;

namespace WebBanDoThoiTrang.ViewModels
{
    public class ChangePassViewModel
    {
        [Required(ErrorMessage = "Bắt buộc nhập Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập Pass")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Mat khau {0} phải có ít nhất {2} kí tự và dài nhất {1} kí tự")]
        [DataType(DataType.Password)]
        [Display(Name = "Confilm Passwork")]
        [Compare("ConfirmNewPassword", ErrorMessage = "mật khẩu chưa trùng khớp.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập ConfilmPass")]
        [DataType(DataType.Password)]
        [Display(Name ="Confilm New Passwork")]
        public string ConfirmNewPassword { get; set; }
    }
}
