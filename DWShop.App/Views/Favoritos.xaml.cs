using DWShop.App.Context;

namespace DWShop.App.Views;

public partial class Favoritos : ContentPage
{
	public Favoritos()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        ProductsList.ItemsSource = await new DataContext().GetFavorites();
        base.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        ProductsList.ItemsSource = null;
        base.OnDisappearing();
    }
}