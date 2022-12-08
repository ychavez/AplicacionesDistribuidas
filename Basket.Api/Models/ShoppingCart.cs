namespace Basket.Api.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            ShoppingCartItems = new List<ShoppingCartItem>();
        }
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
