using MediatR;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQuery : IRequest<List<OrdersListViewModel>>
    {
        public string UserName { get; set; } = null!;
    }
}
