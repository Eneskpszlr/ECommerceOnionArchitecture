using FluentValidation;

namespace OnionVb02.ValidatorStructor.Validators.Product
{
    public class RemoveProductValidator : AbstractValidator<int>
    {
        public RemoveProductValidator()
        {
            RuleFor(Id => Id)
                .GreaterThan(0).WithMessage("Ürün Id 0'dan büyük olmalıdır.");
        }
    }
}
