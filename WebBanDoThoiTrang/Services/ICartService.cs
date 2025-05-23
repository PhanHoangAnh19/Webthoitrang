using System.Collections.Generic;
using WebBanDoThoiTrang.Models;
using WebBanDoThoiTrang.ViewModels;

namespace WebBanDoThoiTrang.Services
{
    public interface ICartService
    {
        CartViewModel GetCart();
        void AddToCart(CartItemViewModel item);
        void UpdateQuantity(int productId, int quantity);
        void Remove(int productId);
        void Clear();
    }
}
