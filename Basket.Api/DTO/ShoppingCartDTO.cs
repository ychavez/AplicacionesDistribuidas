namespace Basket.Api.DTO
{
    public class ShoppingCartDTO
    {
        public string UserName { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public virtual List<ShoppingCartItemDTO> ShoppingCartItems { get; set; } = new();
    }
}
