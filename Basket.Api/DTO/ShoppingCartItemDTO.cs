namespace Basket.Api.DTO
{
    public class ShoppingCartItemDTO
    {
        public int Quantity { get; set; }
        public string? Color { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
    }
}
