using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

public class ErrorController : Controller
{
    // GET
    public IActionResult NotFount404Page()
    {
        return View();
    }
}