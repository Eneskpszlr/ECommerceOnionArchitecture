using FluentValidation;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;

namespace OnionVb02.ValidatorStructor.Validators.Product
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
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
