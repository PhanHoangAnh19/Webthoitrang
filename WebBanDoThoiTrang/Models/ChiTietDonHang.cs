using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanDoThoiTrang.Models
{
    public class ChiTietDonHang
    {
        [Key]
        public int Id { get; set; }

        // FK về DonHang
        [Required]
        public int DonHangId { get; set; }
        public DonHang DonHang { get; set; }

        // FK về SanPham
        [Required]
        public int SanPhamId { get; set; }
        public SanPham SanPham { get; set; }

        // Số lượng và đơn giá tại thời điểm đặt
        [Required]
        public int SoLuong { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal DonGia { get; set; }
    }
}
