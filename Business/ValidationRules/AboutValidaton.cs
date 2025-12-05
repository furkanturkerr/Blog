using Dto.AboutDto;
using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules;

public class AboutValidaton : AbstractValidator<UpdateAboutDto>
{
    public AboutValidaton()
    {
        RuleFor(x=>x.AboutContent).NotNull().WithMessage("Zorunlu Alan");
    }
}