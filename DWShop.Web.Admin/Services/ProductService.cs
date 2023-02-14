using DWShop.Web.Admin.Services.Contracts;
using DWShop.Web.Common.Models;

namespace DWShop.Web.Admin.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task CreateProduct(Product product)
        {
            await httpClient.PostAsJsonAsync("/catalog", product);
        }

        public async Task DeleteProduct(int id)
        {
            await httpClient.DeleteAsync($"/catalog/{id}");
        }

        public async Task EditProduct(Product product)
        {
            await httpClient.PutAsJsonAsync($"/catalog/{product.Id}", product);
        }

        public async Task<Product?> GetProduct(int id)
        {
          return await httpClient.GetFromJsonAsync<Product>($"/catalog/{id}");
        }

        public async Task<List<Product>> GetProducts()
        {
            return (await httpClient.GetFromJsonAsync<List<Product>>($"/catalog"))!;
        }
    }
}
