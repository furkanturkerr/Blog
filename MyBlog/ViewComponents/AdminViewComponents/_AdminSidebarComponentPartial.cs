using Microsoft.AspNetCore.Mvc;

namespace MyBlog.ViewComponents.AdminViewComponents;

public class _AdminSidebarComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}