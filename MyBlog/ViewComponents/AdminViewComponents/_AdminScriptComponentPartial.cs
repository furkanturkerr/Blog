using Microsoft.AspNetCore.Mvc;

namespace MyBlog.ViewComponents.AdminViewComponents;

public class _AdminScriptComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}