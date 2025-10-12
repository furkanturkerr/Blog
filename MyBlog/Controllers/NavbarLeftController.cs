using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;

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
    public IActionResult Index(NavbarLeftViewModel navbarLeft)
    {
        NavbarLeft w = new NavbarLeft();
        if (navbarLeft.NavbarLeftImage != null)
        {
            var extention = Path.GetExtension(navbarLeft.NavbarLeftImage.FileName);
            var newimageName = Guid.NewGuid().ToString() + extention;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/navbarleft", newimageName);
            var stream = new FileStream(location, FileMode.Create);
            navbarLeft.NavbarLeftImage.CopyTo(stream);
            w.NavbarLeftImage = newimageName;
        }
        w.NavbarLefName = navbarLeft.NavbarLefName;
        w.NavbarLeftAddress = navbarLeft.NavbarLeftAddress;
        w.NavbarLeftEmail = navbarLeft.NavbarLeftEmail;
        w.NavbarLeftPhone = navbarLeft.NavbarLeftPhone;
        w.NavbarLeftLinkGithub = navbarLeft.NavbarLeftLinkGithub;
        w.NavbarLeftLinkLinkedin = navbarLeft.NavbarLeftLinkLinkedin;
        w.NavbarLeftLinkInstagram = navbarLeft.NavbarLeftLinkInstagram;
        var values = _navbarLeftService.GetAll();
        return View(values);
    }
}