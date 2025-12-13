using FluentValidation;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;

namespace OnionVb02.ValidatorStructor.Validators.Category
{
    public class RemoveCategoryValidator : AbstractValidator<RemoveCategoryCommand>
    {
        public RemoveCategoryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id geçerli olmalıdır.");
        }
    }
}
