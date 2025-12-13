using FluentValidation;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;

namespace OnionVb02.ValidatorStructor.Validators.OrderDetail
{
    public class RemoveOrderDetailValidator : AbstractValidator<RemoveOrderDetailCommand>
    {
        public RemoveOrderDetailValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id 0'dan büyük olmalıdır.");
        }
    }
}
