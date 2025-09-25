using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

public class NavbarLeftController:Controller
{
    private INavbarLeftService _navbarLeftService;
    public NavbarLeftController(INavbarLeftService navbarLeftService)
    {
        _navbarLeftService = navbarLeftService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var values = _navbarLeftService.GetAll();
        return View(values);
    }
    
    [HttpPost]
    public IActionResult Index(NavbarLeft navbarLeft)
    {
        if (ModelState.IsValid)
        {
            _navbarLeftService.Update(navbarLeft);
            return RedirectToAction("Index"); 
        }
        var values = _navbarLeftService.GetAll();
        return View(values);
    }
}