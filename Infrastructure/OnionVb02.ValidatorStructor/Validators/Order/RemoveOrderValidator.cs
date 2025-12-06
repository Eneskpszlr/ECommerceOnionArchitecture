using FluentValidation;

namespace OnionVb02.ValidatorStructor.Validators.Order
{
    public class RemoveOrderValidator : AbstractValidator<int>
    {
        public RemoveOrderValidator()
        {
            RuleFor(id => id)
                .GreaterThan(0).WithMessage("Sipariş Id geçerli olmalıdır.");
        }
    }
}
