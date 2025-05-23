namespace WebBanDoThoiTrang.Models
{
    public class GioHang
    {
     
            public int MaSanPham { get; set; }
            public string TenSanPham { get; set; } = string.Empty;
            public string HinhAnh { get; set; } = string.Empty;
            public decimal DonGia { get; set; }
            public int Quantity { get; set; }
        
}
}
