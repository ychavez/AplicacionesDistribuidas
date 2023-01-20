using DWShop.App.Context;
using DWShop.App.Models;

namespace DWShop.App.Views;

public partial class Chekout : ContentPage
{
    public Chekout()
    {
        InitializeComponent();
    }

    async Task Checkout()
    {

        var checkoutOrder = new CheckoutOrder
        {
            AddressLine = txtDireccion.Text,
            CardName = txtTarjeta.Text,
            CardNumber = txtTajetaNumero.Text,
            Country = txtPais.Text,
            CVV = txtCVV.Text,
            EmailAddress = txtCorreo.Text,
            Expiration = txtEXP.Text,
            FirstName = txtNombre.Text,
            LastName = txtApellido.Text,
            PaymentMethod = 1,
            State = txtEstado.Text,
            TotalPrice = 1000,
            UserName = txtUsuario.Text,
            ZipCode = txtCP.Text
        };

        await new RestService().PostDataAsync<CheckoutOrder>(checkoutOrder, "Basket/Checkout");

        await Navigation.PopToRootAsync();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Checkout();
    }
}
