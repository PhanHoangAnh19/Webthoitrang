using System.Collections.Generic;
using System.Linq;

namespace WebBanDoThoiTrang.Services
{
    public class CartViewModel
    {
        public List<CartItemViewModel> Items { get; set; } = new();

        // Tính tổng
        public decimal Total => Items.Sum(x => x.DonGia * x.Quantity);
    }
}
