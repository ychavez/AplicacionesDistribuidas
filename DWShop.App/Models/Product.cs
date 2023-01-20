using SQLite;

namespace DWShop.App.Models
{
    public class Product
    { [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public decimal Price { get; set; }
        public string? PhotoURL { get; set; }
    }
}
