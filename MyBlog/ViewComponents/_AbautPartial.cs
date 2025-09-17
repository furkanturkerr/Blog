using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.VievComponents;

public class _AbautPartial:ViewComponent
{
    private readonly IAbautService _abautService;
    public _AbautPartial(IAbautService abautService)
    {
        _abautService = abautService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _abautService.GetAll();
        return View(values);
    }
}