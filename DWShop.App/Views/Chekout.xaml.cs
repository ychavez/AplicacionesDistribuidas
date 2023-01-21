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

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
       // var photo = await MediaPicker.Default.CapturePhotoAsync();
     //   img.Source = ImageSource.FromStream(async x => await photo.OpenReadAsync());
        await TextToSpeech.Default.SpeakAsync("Fotografia tomada con exito");

       await Flashlight.TurnOnAsync();
       await Flashlight.TurnOffAsync();

        var location = await Geolocation.Default.GetLocationAsync();
    }
}
