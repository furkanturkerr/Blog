using Dto.Portfolio;
using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules;

public class CreatePortfolioValidation : AbstractValidator<CreatePortfolioDto>
{
    public CreatePortfolioValidation()
    {
        RuleFor(x=>x.PortfolioCategory).NotEmpty().WithMessage("Kategori zorunlu alan");
        RuleFor(x=>x.PortfolioImage).NotNull().WithMessage("Görsel zorunlu alan");
        RuleFor(x=>x.PortfolioLink).NotEmpty().WithMessage("Link zorunlu alan");
        RuleFor(x=>x.PortfolioName).NotEmpty().WithMessage("Proje adı zorunlu alan");
    }
}