using FluentValidation;
using OnionVb02.PresentationContract.RequestModels.Categories;

namespace OnionVb02.ValidatorStructor.Validators.Category
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryRequestModel>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Kategori adı boş olamaz.")
                .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olabilir.");

            RuleFor(x => x.Description)
                .MaximumLength(200).WithMessage("Açıklama en fazla 200 karakter olabilir.");
        }
    }
}
