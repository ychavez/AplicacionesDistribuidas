using DWShop.Web.Client.Services.Contracts;
using DWShop.Web.Common.Models;
using System.Net.Http.Json;

namespace DWShop.Web.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentException(nameof(httpClient));
           
        }

        public async Task<List<Product>> GetAllAsync()
       => await httpClient.GetFromJsonAsync<List<Product>>("/catalog")
            ?? throw new Exception("Error al traer el catalogo de productos");

        public async Task<Product> GetAsync(int id)
        => await httpClient.GetFromJsonAsync<Product>($"/catalog/{id}")
            ?? throw new Exception($"Error al traer el producto");
    }
}
