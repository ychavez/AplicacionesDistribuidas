using DWShop.App.Models;

namespace DWShop.App.Views;

public partial class Catalog : ContentPage
{
    public Catalog()
    {
        InitializeComponent();
    }


    protected override void OnAppearing()
    {
        ProductsList.ItemsSource = GetProducts();
        base.OnAppearing();
    }

    public List<Product> GetProducts() => new List<Product>
    { new Product {  Description = "Teclado mecanico", Price = 100, PhotoURL = "https://m.media-amazon.com/images/I/61JhIy5rXLL.jpg" },
    new Product {  Description = "Monitor curvo", Price = 1000, PhotoURL = "https://http2.mlstatic.com/D_NQ_NP_998103-MLA48689385379_122021-O.jpg" },
    new Product {  Description = "Mouse gamer", Price = 100,
        PhotoURL = "https://www.steren.com.mx/media/catalog/product/cache/b69086f136192bea7a4d681a8eaf533d/image/21436ed0f/mouse-usb-gamer-800-1200-1600-2000-dpi.jpg" }};
}