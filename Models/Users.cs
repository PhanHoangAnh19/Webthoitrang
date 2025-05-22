using Microsoft.AspNetCore.Identity;

namespace WebBanDoThoiTrang.Models
{
    public class Users : IdentityUser
    {
        public string Fullname { get; set; }
    }
}
