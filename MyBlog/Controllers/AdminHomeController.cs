using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;
[Authorize]
public class AdminHomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}