namespace WebBanDoThoiTrang.Services
{
    public class CartItemViewModel
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; } = "";
        public decimal DonGia { get; set; }
        public int Quantity { get; set; }
        public string HinhAnh { get; set; } = "";
    }
}
