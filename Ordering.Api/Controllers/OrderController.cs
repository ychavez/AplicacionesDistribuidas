using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Orders.Commands.Checkout;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;

namespace Ordering.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersListViewModel>>> GetOrders([FromQuery] GetOrdersListQuery query)
            => await mediator.Send(query);

        [HttpPost]
        public async Task<ActionResult> PostOrder([FromBody] CheckoutOrderCommand command)
            => Ok(await mediator.Send(command));

    }
}
