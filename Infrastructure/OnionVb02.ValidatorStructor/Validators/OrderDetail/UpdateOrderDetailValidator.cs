using FluentValidation;
using OnionVb02.PresentationContract.RequestModels.OrderDetails;

namespace OnionVb02.ValidatorStructor.Validators.OrderDetail
{
    public class UpdateOrderDetailValidator : AbstractValidator<UpdateOrderDetailRequestModel>
    {
        public UpdateOrderDetailValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id 0'dan büyük olmalıdır.");
            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("OrderId 0'dan büyük olmalıdır.");
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId 0'dan büyük olmalıdır.");
        }
    }
}
