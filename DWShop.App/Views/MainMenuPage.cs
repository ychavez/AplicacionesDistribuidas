namespace DWShop.App.Views
{
    public class MainMenuPage: TabbedPage
    {
        public MainMenuPage()
        {
            Children.Add(new Catalog());
            Children.Add(new Favoritos());
            Children.Add(new Pedidos());

        }
    }
}
