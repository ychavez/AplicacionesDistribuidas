using DWShop.App.Context;
using DWShop.App.Models;

namespace DWShop.App.Views;

public partial class Catalog : ContentPage
{
    public Catalog()
    {
        InitializeComponent();
    }


    protected override async void OnAppearing()
    {
        ProductsList.ItemsSource = await GetProducts();
        base.OnAppearing();
    }

    public async Task<List<Product>> GetProducts()

    {

        var data = await (new RestService().GetDataAsync<Product>("products"));
        return data;
    }

}