using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules;

public class SkilsValidation : AbstractValidator<Skills>
{
    public SkilsValidation()
    {
        RuleFor(x=>x.SkillsContent).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x => x.SkillsNumber).NotNull().WithMessage("Zorunlu Alan");
    }
}