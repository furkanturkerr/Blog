using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules;

public class PortfolioValidation : AbstractValidator<Portfolio>
{
    public PortfolioValidation()
    {
        RuleFor(x=>x.PortfolioCategory).NotEmpty().WithMessage("Kategori zorunlu alan");
        RuleFor(x=>x.PortfolioImage).NotNull().WithMessage("Görsel zorunlu alan");
        RuleFor(x=>x.PortfolioLink).NotEmpty().WithMessage("Link zorunlu alan");
        RuleFor(x=>x.PortfolioName).NotEmpty().WithMessage("Proje adı zorunlu alan");
    }
}