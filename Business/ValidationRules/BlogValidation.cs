using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules;

public class BlogValidation : AbstractValidator<Blog>
{
    public BlogValidation()
    {
        RuleFor(x=>x.BlogTitle).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x=>x.BlogText).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x=>x.BlogImage).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x => x.CategoryId)
            .GreaterThan(0)
            .WithMessage("Kategori seçmek zorunludur.");
        RuleFor(x => x.BlogSlug)
            .NotEmpty().WithMessage("Kategori slug boş olamaz.")
            .Matches("^[a-z0-9-]+$")
            .WithMessage("Slug sadece küçük harf, rakam ve '-' içerebilir. Türkçe karakter kullanmayın.");
    }
}