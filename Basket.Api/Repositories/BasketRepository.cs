using Basket.Api.DataContext;
using Basket.Api.DTO;
using Basket.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Basket.Api.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly BasketContext basketContext;

        public BasketRepository(BasketContext basketContext)
        {
            this.basketContext = basketContext;
        }

        private async Task<ShoppingCart?> FindBasket(string userName)
            => await basketContext
               .ShoppingCarts
               .Include(d => d.ShoppingCartItems)
               .SingleOrDefaultAsync(x => x.UserName == userName);

        public async Task UpdateBasket(ShoppingCartDTO shoppingCart)
        {
            var basket = await FindBasket(shoppingCart.UserName);

            if (basket is not null)
            {
                basketContext.Entry(basket).State = EntityState.Modified;
                basket.ShoppingCartItems.Clear();
                AgregarDetalle(basket, shoppingCart.ShoppingCartItems);

                await basketContext.SaveChangesAsync();
            }
            else
            {
                var cart = new ShoppingCart()
                {
                    TotalPrice = shoppingCart.TotalPrice,
                    UserName = shoppingCart.UserName
                };

                AgregarDetalle(cart, shoppingCart.ShoppingCartItems);

                basketContext.ShoppingCarts.Add(cart);
                await basketContext.SaveChangesAsync();
            }
        }


        private void AgregarDetalle(ShoppingCart basket, List<ShoppingCartItemDTO> items)
        {
            foreach (var item in items)
            {
                basket.ShoppingCartItems.Add(new ShoppingCartItem()
                {
                    Color = item.Color,
                    Price = item.Price,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity
                });
            }
        }

        public async Task DeleteBasket(string userName)
        {
            var basket = await FindBasket(userName);

            if (basket is null)
                return;

            basketContext.Remove(basket);
            await basketContext.SaveChangesAsync();
        }

        public async Task<ShoppingCart> GetBasket(string userName)
            => await FindBasket(userName) ?? new ShoppingCart();


        public async Task UpdateBasket(ShoppingCart shoppingCart)
        {
            var basket = await GetBasket(shoppingCart.UserName);
            if (basket is not null)
            {
                basketContext.Entry(shoppingCart).State = EntityState.Modified;
                await basketContext.SaveChangesAsync();
                return;
            }

            basketContext.ShoppingCarts.Add(shoppingCart);
            await basketContext.SaveChangesAsync();
           
        }
    }
}
