using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebBanDoThoiTrang.Models
{
    public class SanPham
    {
        [Key]                    
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

       
        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
