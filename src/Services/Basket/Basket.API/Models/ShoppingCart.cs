namespace Basket.API.Models
{
    public class ShoppingCart
    {
        public string UserName { get; set; } = default!;
        public List<ShoppingCartItem> items { get; set; } = new();
        public decimal TotalPrice => items.Sum(x => x.Price * x.Quantity);

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        // Required for mapping
        public ShoppingCart()
        {
            
        }
    }
}
