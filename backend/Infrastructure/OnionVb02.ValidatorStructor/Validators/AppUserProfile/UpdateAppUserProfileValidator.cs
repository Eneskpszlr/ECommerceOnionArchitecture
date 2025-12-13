using FluentValidation;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;

namespace OnionVb02.ValidatorStructor.Validators.AppUserProfile
{
    public class UpdateAppUserProfileValidator : AbstractValidator<UpdateAppUserProfileCommand>
    {
        public UpdateAppUserProfileValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("İsim boş olamaz.")
                .MaximumLength(50).WithMessage("İsim en fazla 50 karakter olabilir.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyisim boş olamaz.")
                .MaximumLength(50).WithMessage("Soyisim en fazla 50 karakter olabilir.");
        }
    }
}
