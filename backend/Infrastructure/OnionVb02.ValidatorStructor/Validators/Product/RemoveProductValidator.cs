using FluentValidation;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;

namespace OnionVb02.ValidatorStructor.Validators.Product
{
    public class RemoveProductValidator : AbstractValidator<RemoveProductCommand>
    {
        public RemoveProductValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Ürün Id 0'dan büyük olmalıdır.");
        }
    }
}
