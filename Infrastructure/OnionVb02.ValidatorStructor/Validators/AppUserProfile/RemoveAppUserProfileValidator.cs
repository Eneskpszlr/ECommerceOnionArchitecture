using FluentValidation;

namespace OnionVb02.ValidatorStructor.Validators.AppUserProfile
{
    public class RemoveAppUserProfileValidator : AbstractValidator<int>
    {
        public RemoveAppUserProfileValidator()
        {
            RuleFor(id => id)
                .GreaterThan(0).WithMessage("Id geçerli olmalıdır.");
        }
    }
}
