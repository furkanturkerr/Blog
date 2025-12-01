using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules;

public class NavbarLeftValidation : AbstractValidator<NavbarLeft>
{
    public NavbarLeftValidation()
    {
        RuleFor(x=>x.NavbarLeftImage).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x=>x.NavbarLefName).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x=>x.NavbarLeftEmail).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x=>x.NavbarLeftPhone).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x=>x.NavbarLeftText).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x=>x.NavbarLeftAddress).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x=>x.NavbarLeftLinkGithub).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x=>x.NavbarLeftLinkInstagram).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x=>x.NavbarLeftLinkLinkedin).NotNull().WithMessage("Zorunlu Alan");
    }
}