using FluentValidation;

namespace OnionVb02.ValidatorStructor.Validators.OrderDetail
{
    public class RemoveOrderDetailValidator : AbstractValidator<int>
    {
        public RemoveOrderDetailValidator()
        {
            RuleFor(id => id)
                .GreaterThan(0).WithMessage("Id 0'dan büyük olmalıdır.");
        }
    }
}
