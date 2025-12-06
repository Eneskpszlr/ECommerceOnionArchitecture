using FluentValidation;

namespace OnionVb02.ValidatorStructor.Validators.Category
{
    public class RemoveCategoryValidator : AbstractValidator<int>
    {
        public RemoveCategoryValidator()
        {
            RuleFor(id => id)
                .GreaterThan(0).WithMessage("Id geçerli olmalıdır.");
        }
    }
}
