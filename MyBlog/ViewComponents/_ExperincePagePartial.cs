using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.VievComponents;

public class _ExperincePagePartial:ViewComponent
{
    private readonly IExperincePageService _experincePageService;
    public _ExperincePagePartial(IExperincePageService experincePageService)
    {
        _experincePageService = experincePageService;
    }
    public IViewComponentResult Invoke()
    {
        var values = _experincePageService.GetAll();
        return View(values);
    }
}