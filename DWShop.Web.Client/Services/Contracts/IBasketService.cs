using DWShop.Web.Client.DTO;

namespace DWShop.Web.Client.Services.Contracts
{
    public interface IBasketService
    {
        Task Checkout(CheckoutDTO checkout);
        Task<BasketDTO> GetBasketAsync(string userName);
        Task UpdateBasket(BasketDTO basket);
    }
}