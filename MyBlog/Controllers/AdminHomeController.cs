using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

public class AdminHomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}