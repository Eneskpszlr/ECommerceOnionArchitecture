using FluentValidation;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;

namespace OnionVb02.ValidatorStructor.Validators.OrderDetail
{
    public class UpdateOrderDetailValidator : AbstractValidator<UpdateOrderDetailCommand>
    {
        public UpdateOrderDetailValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id 0'dan büyük olmalıdır.");
            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("OrderId 0'dan büyük olmalıdır.");
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId 0'dan büyük olmalıdır.");
        }
    }
}
