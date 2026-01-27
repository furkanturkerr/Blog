using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

public class AdminController : Controller
{
    private readonly IContactService  _contactService;

    public AdminController(IContactService contactService)
    {
        _contactService = contactService;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    // GET
    public IActionResult Anasayfa()
    {
        var values = _contactService
            .GetAll()
            .OrderByDescending(x => x.CreatedDate)
            .Take(5)
            .ToList();

        return View(values);
    }

}