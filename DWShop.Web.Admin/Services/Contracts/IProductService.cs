using DWShop.Web.Common.Models;

namespace DWShop.Web.Admin.Services.Contracts
{
    public interface IProductService
    {
        Task DeleteProduct(int id);
        Task<List<Product>> GetProducts();
        Task<Product?> GetProduct(int id);
        Task EditProduct(Product product);
        Task CreateProduct(Product product);
    }
}
