using Microsoft.AspNetCore.Mvc;

namespace MyBlog.ViewComponents.Thema;

public class _ThemaNavbarPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}