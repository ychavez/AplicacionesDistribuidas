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
        var shoppingCart = await new RestService().GetSingleAsync<ShoppingCart>("Basket/Yael");
        cartList.ItemsSource = shoppingCart.ShoppingCartItems;

        base.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        cartList.ItemsSource = null;
        base.OnDisappearing();
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Chekout());
    }
}