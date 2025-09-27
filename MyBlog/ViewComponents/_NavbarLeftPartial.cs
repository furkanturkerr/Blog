using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.ViewComponents;

public class _NavbarLeftPartial:ViewComponent
{
    private readonly INavbarLeftService _navbarLeftService;
    public _NavbarLeftPartial(INavbarLeftService navbarLeftService)
    {
        _navbarLeftService = navbarLeftService;
    }
    
    public IViewComponentResult Invoke()
    {
        var values = _navbarLeftService.GetAll();
        return View(values);
    }
}