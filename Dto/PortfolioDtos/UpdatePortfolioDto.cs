using Microsoft.AspNetCore.Http;

namespace Dto.Portfolio;

public class UpdatePortfolioDto
{
    public int PortfolioId { get; set; }
    public IFormFile? PortfolioImage { get; set; } // upload için
    public string? PortfolioImagePath { get; set; } // db'ye gidecek yol

    public string PortfolioLink { get; set; } = string.Empty;
    public string PortfolioName { get; set; } = string.Empty;
    public string PortfolioCategory { get; set; } = string.Empty;
}