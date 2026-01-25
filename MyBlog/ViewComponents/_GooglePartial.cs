using System.Linq;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.ViewComponents;

public class _GooglePartial : ViewComponent
{
    private readonly IGoogleService _googleService;
    
    public _GooglePartial(IGoogleService googleService)
    {
        _googleService = googleService;
    }
    
    public IViewComponentResult Invoke()
    {
        var values = _googleService.GetAll().FirstOrDefault();
        return View(values);
    }
}