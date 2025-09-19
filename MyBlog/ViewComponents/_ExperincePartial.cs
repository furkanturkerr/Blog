using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.VievComponents;

public class _ExperincePartial:ViewComponent
{
    private readonly IExperinceService _experinceService;
    public _ExperincePartial(IExperinceService experinceService)
    {
       _experinceService = experinceService;
    }
    public IViewComponentResult Invoke()
    {
        var values = _experinceService.GetAll();
        return View(values);
    }
}