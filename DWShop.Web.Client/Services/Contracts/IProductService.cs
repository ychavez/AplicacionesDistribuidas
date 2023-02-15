using DWShop.Web.Common.Models;

namespace DWShop.Web.Client.Services.Contracts
{
    public interface IProductService
    {
        Task<Product> GetAsync(int id);
        Task<List<Product>> GetAllAsync();
    }
}
