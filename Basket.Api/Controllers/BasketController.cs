using Basket.Api.DTO;
using Basket.Api.Models;
using Basket.Api.Repositories;
using EventBus.Messages.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository basketRepository;
        private readonly IPublishEndpoint publishEndpoint;

        public BasketController(IBasketRepository basketRepository, IPublishEndpoint publishEndpoint)
        {
            this.basketRepository = basketRepository;
            this.publishEndpoint = publishEndpoint;
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

        [HttpPost("Checkout")]
        public async Task<ActionResult> Checkout([FromBody] BasketCheckoutEvent basketCheckoutEvent) 
        {
            //TODO: Validations here!

            await publishEndpoint.Publish(basketCheckoutEvent);
            
            return Accepted();
        
        }

    }
    
}
