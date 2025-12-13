using FluentValidation;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;

namespace OnionVb02.ValidatorStructor.Validators.AppUserProfile
{
    public class RemoveAppUserProfileValidator : AbstractValidator<RemoveAppUserProfileCommand>
    {
        public RemoveAppUserProfileValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id geçerli olmalıdır.");
        }
    }
}
