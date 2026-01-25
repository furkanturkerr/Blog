using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

public class CategoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}