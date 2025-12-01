using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules;

public class ServiceValidation: AbstractValidator<Service>
{
    public ServiceValidation()
    {
        RuleFor(x=>x.ServiceContent).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x=>x.ServiceText).NotNull().WithMessage("Zorunlu Alan");
        RuleFor(x=>x.ServiceIcon).NotNull().WithMessage("Zorunlu Alan");
    }
}