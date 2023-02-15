using DWShop.Web.Client;
using DWShop.Web.Client.Services;
using DWShop.Web.Client.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace DWShop.Web.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => 
            new HttpClient { BaseAddress = 
            new Uri("http://gdlsoft.ddns.net:99/") });

            builder.Services.AddScoped<IProductService, ProductService>();

            await builder.Build().RunAsync();
        }
    }
}