using FluentValidation;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryValidator: AbstractValidator<GetOrdersListQuery>
    {
        public GetOrdersListQueryValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(3)
                .WithMessage("El username no puede ser menor que 4 caracteres no manche oiga")
                .MaximumLength(20);
        }
    }
}
