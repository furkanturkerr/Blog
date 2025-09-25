using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyBlog.VievComponents;

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