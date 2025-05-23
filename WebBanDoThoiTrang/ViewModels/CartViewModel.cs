using System;
using System.Collections.Generic;
using System.Linq;

namespace WebBanDoThoiTrang.ViewModels
{
    public class CartViewModel
    {
       
        public List<CartItemViewModel> Items { get; set; } = new();

        
        public decimal Total
            => Items.Sum(x => x.DonGia * x.Quantity);
    }
}
