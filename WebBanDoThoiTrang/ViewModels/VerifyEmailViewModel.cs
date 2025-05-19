using System.ComponentModel.DataAnnotations;

namespace WebBanDoThoiTrang.ViewModels
{   // xac thuc email
    public class VerifyEmailViewModel
    {

        [Required(ErrorMessage = "Bắt buộc nhập Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
