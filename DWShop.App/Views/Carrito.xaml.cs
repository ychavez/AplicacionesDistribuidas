using DWShop.App.Context;
using DWShop.App.Models;

namespace DWShop.App.Views;

public partial class Carrito : ContentPage
{
	public Carrito()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        var shoppingCart = await new RestService().GetSingleAsync<ShoppingCart>("Basket/marco.villegas");
        cartList.ItemsSource = shoppingCart.ShoppingCartItems;

        base.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        cartList.ItemsSource = null;
        base.OnDisappearing();
    }
}