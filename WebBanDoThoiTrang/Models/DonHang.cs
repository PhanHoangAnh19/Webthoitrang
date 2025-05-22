using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanDoThoiTrang.Models
{
    public class DonHang
    {
        [Key]                      // ← Đánh dấu khoá chính
        public int MaDonHang { get; set; }

        [Required, ForeignKey(nameof(KhachHang))]
        public int MaKhachHang { get; set; }

        public DateTime NgayDatHang { get; set; } = DateTime.Now;

        public decimal TongTien { get; set; }

        // Navigation
        public KhachHang KhachHang { get; set; }
        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
