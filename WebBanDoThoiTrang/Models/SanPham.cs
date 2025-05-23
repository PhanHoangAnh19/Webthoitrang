using System.ComponentModel.DataAnnotations;

namespace WebBanDoThoiTrang.Models
{
    public class SanPham
    {
        [Key]                      // ← Đánh dấu khoá chính
        public int MaSanPham { get; set; }

        [Required, StringLength(150)]
        public string TenSanPham { get; set; }

        public string MoTa { get; set; }
        [StringLength(255)]
        public string HinhAnh { get; set; }

        [Required]
        public decimal DonGia { get; set; }

        public decimal? GiaCu { get; set; }
        
        [Required]
        public int SoLuongTon { get; set; }

        // Navigation
        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
