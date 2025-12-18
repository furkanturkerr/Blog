using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;
[AllowAnonymous]
public class ErrorController : Controller
{
    // GET
    public IActionResult NotFount404Page()
    {
        return View();
    }
}