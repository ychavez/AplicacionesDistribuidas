using DWShop.App.Context;
using DWShop.App.Models;

namespace DWShop.App.Views;

public partial class Catalog : ContentPage
{
    public Catalog()
    {
        InitializeComponent();


    }


    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        ProductsList.ItemsSource = null;
    }

    protected override async void OnAppearing()
    {
        products = await new RestService().GetDataAsync<Product>("catalog");

        ProductsList.ItemsSource = products ?? new();
        /// base.OnAppearing();
    }

    public List<Product> products { get; set; } = new();




    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Carrito());
    }


    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var product = (Product)((ImageButton)sender).BindingContext;

        var shoppingCart = new ShoppingCart()
        {
            TotalPrice = 1000,
            UserName = "Yael",

            ShoppingCartItems = new List<ShoppingCartItem>
            {
                new ShoppingCartItem
                {
                    ProductId = product.Id,
                    Price = product.Price,
                    ProductName = product.Name,
                    Quantity = 1
                }
            }
        };

        await new RestService().PostDataAsync(shoppingCart, "Basket");

    }
}
