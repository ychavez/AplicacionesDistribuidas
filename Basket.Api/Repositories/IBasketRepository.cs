using Basket.Api.DTO;
using Basket.Api.Models;

namespace Basket.Api.Repositories
{
    public interface IBasketRepository
    {
        Task DeleteBasket(string userName);
        Task<ShoppingCart> GetBasket(string userName);
        Task UpdateBasket(ShoppingCart shoppingCart);
        Task UpdateBasket(ShoppingCartDTO shoppingCart);

    }
}
