using System.ComponentModel.DataAnnotations;

namespace Basket.Api.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string? Color { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int ShoppingCartId { get; set; }
        //public  ShoppingCart ShoppingCart { get; set; } = null!;

    }
}
