using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.VievComponents;

public class _ServicePartial:ViewComponent
{
    private readonly IServiceService _serviceService;
    public _ServicePartial(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }
    
    public IViewComponentResult Invoke()
    {
        var values = _serviceService.GetAll();
        return View(values);
    }
}