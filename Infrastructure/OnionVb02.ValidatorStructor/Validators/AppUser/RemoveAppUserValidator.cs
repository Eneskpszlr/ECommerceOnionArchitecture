using FluentValidation;

namespace OnionVb02.ValidatorStructor.Validators.AppUser
{
    public class RemoveAppUserValidator : AbstractValidator<int>
    {
        public RemoveAppUserValidator()
        {
            RuleFor(id => id)
                .GreaterThan(0).WithMessage("Id geçerli olmalıdır.");
        }
    }
}
