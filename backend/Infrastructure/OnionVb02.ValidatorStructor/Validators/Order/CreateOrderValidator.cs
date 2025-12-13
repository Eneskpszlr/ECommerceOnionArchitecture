using FluentValidation;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;

namespace OnionVb02.ValidatorStructor.Validators.Order
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.AppUserId)
                .GreaterThan(0).WithMessage("Kullanıcı Id geçerli olmalıdır.");
            RuleFor(x => x.ShippingAddress)
                .NotEmpty().WithMessage("Teslimat adresi boş olamaz.")
                .MaximumLength(500).WithMessage("Teslimat adresi en fazla 500 karakter olabilir.");
        }
    }
}
