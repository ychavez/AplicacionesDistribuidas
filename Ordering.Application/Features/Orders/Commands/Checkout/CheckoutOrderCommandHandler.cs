using AutoMapper;
using MediatR;
using Ordering.Application.Contracts;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Orders.Commands.Checkout;

public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
{
    private readonly IMapper mapper;
    private readonly IGenericRepository<Order> repository;

    public CheckoutOrderCommandHandler(IMapper mapper, IGenericRepository<Order> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
    {
        var orderEntity = mapper.Map<Order>(request);
        var newOrder = await repository.AddAsync(orderEntity);
        return newOrder.Id;
    }
}
