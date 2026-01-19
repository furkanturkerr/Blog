using Dto.Portfolio;
using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules;

public class UpdatePortfolioValidation : AbstractValidator<UpdatePortfolioDto>
{
    public UpdatePortfolioValidation()
    {
        RuleFor(x=>x.PortfolioCategory).NotEmpty().WithMessage("Kategori zorunlu alan");
        // PortfolioImage güncelleme sırasında opsiyonel (yeni görsel yüklemek isteğe bağlı)
        RuleFor(x=>x.PortfolioLink).NotEmpty().WithMessage("Link zorunlu alan");
        RuleFor(x=>x.PortfolioName).NotEmpty().WithMessage("Proje adı zorunlu alan");
    }
}