using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules;

public class EducationValidation:AbstractValidator<Education>
{
    public EducationValidation()
    {
        RuleFor(x=>x.EducationContentlow).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x=>x.EducationText).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x=>x.EducationTime).NotNull().WithMessage("Zorunlu Alan");
    }
}