using AutoMapper;
using MediatR;
using Ordering.Application.Contracts;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList;

public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrdersListViewModel>>
{
    private readonly IGenericRepository<Order> repository;
    private readonly IMapper mapper;

    public GetOrdersListQueryHandler(IGenericRepository<Order> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<List<OrdersListViewModel>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
    {
        var orders = await repository.GetAllAsync(x => x.UserName == request.UserName);

        return mapper.Map<List<OrdersListViewModel>>(orders);
    }


}

