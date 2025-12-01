using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules;

public class PortfolioValidation : AbstractValidator<Portfolio>
{
    public PortfolioValidation()
    {
        RuleFor(x=>x.PortfolioCategory).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x=>x.PortfolioImage).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x=>x.PortfolioLink).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x=>x.PortfolioName).NotNull().WithMessage("Zorunlu Alan");
    }
}