using FluentValidation;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;

namespace OnionVb02.ValidatorStructor.Validators.Order
{
    public class RemoveOrderValidator : AbstractValidator<RemoveOrderCommand>
    {
        public RemoveOrderValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Sipariş Id geçerli olmalıdır.");
        }
    }
}
