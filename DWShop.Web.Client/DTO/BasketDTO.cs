namespace DWShop.Web.Client.DTO
{
    public class BasketDTO
    {
        public string UserName { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public List<BasketItemDTO> ShoppingCartItems { get; set; } = new();
    }
    public class BasketItemDTO 
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
    }
}
