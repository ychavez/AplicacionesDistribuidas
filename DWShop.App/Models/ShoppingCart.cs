namespace DWShop.App.Models
{
    public class ShoppingCart
    {
        public string UserName { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = new();
    }

    public class ShoppingCartItem
    {
        public int Quantity { get; set; }
        public string? Color { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
    }
}
