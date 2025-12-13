using FluentValidation;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;

namespace OnionVb02.ValidatorStructor.Validators.AppUser
{
    public class RemoveAppUserValidator : AbstractValidator<RemoveAppUserCommand>
    {
        public RemoveAppUserValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id geçerli olmalıdır.");
        }
    }
}
