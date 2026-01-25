using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules;

public class CategoryValidation : AbstractValidator<Category>
{
    public CategoryValidation()
    {
        RuleFor(x=>x.CategoryName).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x => x.CategorySlug)
            .NotEmpty().WithMessage("Kategori slug boş olamaz.")
            .Matches("^[a-z0-9-]+$")
            .WithMessage("Slug sadece küçük harf, rakam ve '-' içerebilir. Türkçe karakter kullanmayın.");
    }
}