using Microsoft.AspNetCore.Mvc;

namespace MyBlog.ViewComponents.Thema;

public class _ThemaScriptComponentPartial : ViewComponent
{
    public  IViewComponentResult Invoke()
    {
        return View();
    }
}