using System.ComponentModel.DataAnnotations;

namespace DWShop.Web.Common.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Porfavor introduce un valor en el campo nombre")]
        [MinLength(3)]
        public string Name { get; set; } = null!;
        [Required]
        public string Category { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public string Summary { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string? PhotoURL { get; set; }
    }
}
