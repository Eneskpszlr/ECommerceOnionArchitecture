using FluentValidation;
using OnionVb02.PresentationContract.RequestModels.Products;

namespace OnionVb02.ValidatorStructor.Validators.Product
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductRequestModel>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Ürün Id 0'dan büyük olmalıdır.");
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün adı boş olamaz.")
                .MaximumLength(100).WithMessage("Ürün adı en fazla 100 karakter olabilir.");
            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Birim fiyat 0'dan büyük olmalıdır.");
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("KategoriId 0'dan büyük olmalıdır.");
        }
    }
}
