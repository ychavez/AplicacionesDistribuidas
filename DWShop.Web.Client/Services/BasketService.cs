using DWShop.Web.Client.DTO;
using DWShop.Web.Client.Services.Contracts;
using System.Net.Http.Json;

namespace DWShop.Web.Client.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient client;
        private readonly IProductService productService;

        public BasketService(HttpClient client, IProductService productService)
        {
            this.client = client;
            this.productService = productService;
        }

        public async Task Checkout(CheckoutDTO checkout)
        {
            await client.PostAsJsonAsync("/Basket/Checkout", checkout);
        }

        public async Task<BasketDTO> GetBasketAsync(string userName)
        {
            var basket = await client.GetFromJsonAsync<BasketDTO>($"/Basket/{userName}")
                ?? throw new Exception("Error al intentar traer la canasta");
            return basket;

        }
        public async Task UpdateBasket(BasketDTO basket)
        {
            await client.PostAsJsonAsync("/Basket", basket);
        }

    }
}
