using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules;

public class ExperinceValidation : AbstractValidator<Experience>
{
    public ExperinceValidation()
    {
        RuleFor(x=>x.ExperiencImage).NotNull().WithMessage("Zorunlu Alan");
    }
}