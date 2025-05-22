using System.ComponentModel.DataAnnotations;

namespace WebBanDoThoiTrang.Models
{
    public class KhachHang
    {
        [Key]                      // ← Đánh dấu khoá chính
        public int MaKhachHang { get; set; }

        [Required, StringLength(100)]
        public string HoTen { get; set; }

        [Required, EmailAddress, StringLength(150)]
        public string Email { get; set; }

        [StringLength(20)]
        public string DienThoai { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        // Navigation
        public ICollection<DonHang> DonHangs { get; set; }
    }
}
