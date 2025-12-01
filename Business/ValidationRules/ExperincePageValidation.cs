using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules;

public class ExperincePageValidation : AbstractValidator<ExperiencePage>
{
    public ExperincePageValidation()
    {
        RuleFor(x=>x.ExperiencePageText).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x=>x.ExperiencePageContentlow).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x=>x.ExperiencePageTime).NotNull().WithMessage("Zorunlu Alan");
    }
}