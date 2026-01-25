using System.Linq;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.VievComponents;

public class _AboutPartial:ViewComponent
{
    private readonly IAbautService _abautService;
    public _AboutPartial(IAbautService abautService)
    {
        _abautService = abautService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _abautService.GetAll().FirstOrDefault();
        return View(values);
    }
}