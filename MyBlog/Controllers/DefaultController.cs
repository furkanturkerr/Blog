using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;
[AllowAnonymous]
public class DefaultController:Controller
{
    public IActionResult Anasayfa()
    {
        return View();
    }
    
    public IActionResult Ozgecmis()
    {
        return View();
    }
    
    public IActionResult Iletisim()
    {
        return View();
    }
    
    public IActionResult BLog()
    {
        return View();
    }

    public IActionResult Projeler()
    {
        return View();
    }
}