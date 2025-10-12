namespace MyBlog.Models;

public class  PortfolioViewModel
{
    public int PortfolioId { get; set; }
    public string PortfolioCategory { get; set; }
    public string PortfolioName { get; set; }
    public string PortfolioLink { get; set; }
    
    public string PortfolioStatus { get; set; }
    public IFormFile PortfolioImageFile { get; set; }   
}