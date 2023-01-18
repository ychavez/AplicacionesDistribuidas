using DWShop.App.Views;

namespace DWShop.App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new MainMenuPage());
        }
    }
}