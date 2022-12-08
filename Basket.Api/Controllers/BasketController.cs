using Basket.Api.DTO;
using Basket.Api.Models;
using Basket.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            return await basketRepository.GetBasket(userName);

        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCartDTO>> UpdateBasket([FromBody] ShoppingCartDTO shoppingCart)
        {
            await basketRepository.UpdateBasket(shoppingCart);
            return shoppingCart;
        }

        [HttpDelete("{userName}")]
        public async Task<ActionResult<ShoppingCart>> DeleteBasket(string userName)
        {
            await basketRepository.DeleteBasket(userName);
            return Ok();
        
        }

    }
    
}
