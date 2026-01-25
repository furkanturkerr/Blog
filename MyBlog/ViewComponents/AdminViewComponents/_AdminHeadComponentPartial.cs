using Microsoft.AspNetCore.Mvc;

namespace MyBlog.ViewComponents.AdminViewComponents;

public class _AdminHeadComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}