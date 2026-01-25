using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

public class AdminController : Controller
{
    
    public IActionResult Index()
    {
        return View();
    }
    
    // GET
    public IActionResult Anasayfa()
    {
        return View();
    }
}