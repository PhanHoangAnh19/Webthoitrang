using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using WebBanDoThoiTrang.ViewModels;

namespace WebBanDoThoiTrang.Services
{
    public class SessionCartService : ICartService
    {
        private const string SESSION_KEY = "Cart";
        private readonly IHttpContextAccessor _http;

        public SessionCartService(IHttpContextAccessor http)
        {
            _http = http;
        }

        public CartViewModel GetCart()
        {
            var session = _http.HttpContext.Session;
            var data = session.GetString(SESSION_KEY);
            if (string.IsNullOrEmpty(data))
                return new CartViewModel();
            return JsonSerializer.Deserialize<CartViewModel>(data)!;
        }

        private void Save(CartViewModel cart)
        {
            var session = _http.HttpContext.Session;
            session.SetString(SESSION_KEY, JsonSerializer.Serialize(cart));
        }

        public void AddToCart(CartItemViewModel item)
        {
            var cart = GetCart();
            var exist = cart.Items.FirstOrDefault(x => x.MaSanPham == item.MaSanPham);
            if (exist != null)
                exist.Quantity += item.Quantity;
            else
                cart.Items.Add(item);
            Save(cart);
        }

        public void UpdateQuantity(int productId, int quantity)
        {
            var cart = GetCart();
            var exist = cart.Items.FirstOrDefault(x => x.MaSanPham == productId);
            if (exist != null)
                exist.Quantity = quantity;
            Save(cart);
        }

        public void Remove(int productId)
        {
            var cart = GetCart();
            cart.Items.RemoveAll(x => x.MaSanPham == productId);
            Save(cart);
        }

        public void Clear()
        {
            _http.HttpContext.Session.Remove(SESSION_KEY);
        }
    }
}
