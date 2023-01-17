using AutoMapper;
using EventBus.Messages.Events;
using Ordering.Application.Features.Orders.Commands.Checkout;

namespace Ordering.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CheckoutOrderCommand, BasketCheckoutEvent>().ReverseMap();
        }

    }
}
