using System;

namespace WebBanDoThoiTrang.ViewModels
{
    public class CartItemViewModel
    {
        // Mã sản phẩm
        public int MaSanPham { get; set; }

        // Tên hiển thị
        public string TenSanPham { get; set; } = "";

        // Đơn giá (lấy từ model SanPham)
        public decimal DonGia { get; set; }

        // Số lượng người dùng chọn
        public int Quantity { get; set; }

        // Đường dẫn ảnh
        public string HinhAnh { get; set; } = "";
    }
}
