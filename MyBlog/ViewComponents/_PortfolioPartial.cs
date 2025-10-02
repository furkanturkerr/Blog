using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.ViewComponents;

public class _PortfolioPartial:ViewComponent
{
    private readonly IPortfolioService _portfolioService;
    public _PortfolioPartial(IPortfolioService portfolioService)
    {
        _portfolioService = portfolioService;
    }
    public IViewComponentResult Invoke()
    {
        var values = _portfolioService.GetAll();
        
        return View(values);
    }
}