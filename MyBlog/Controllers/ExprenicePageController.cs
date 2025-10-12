using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

public class ExprenicePageController : Controller
{
    private readonly IExperincePageService _experincepageService;
    public ExprenicePageController(IExperincePageService experincepageService)
    {
        _experincepageService = experincepageService;
    }
    [HttpGet]
    public IActionResult Index()
    {
        var vievs = _experincepageService.GetAll();
        return View(vievs);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(ExperiencePage experiencePage)
    {
        if (ModelState.IsValid)
        {
            _experincepageService.Insert(experiencePage);
            return RedirectToAction("Index");
        }
        return View();   
    }
    
    [HttpPost]
    public IActionResult Index(ExperiencePage experiencePage)
    {
        if (ModelState.IsValid)
        {
            _experincepageService.Update(experiencePage);
            return RedirectToAction("Index"); 
        }
        var services = _experincepageService.GetAll();
        return View(services);
    }
    
    public IActionResult Delete(int id)
    {
        var values = _experincepageService.GetById(id);
        _experincepageService.Delete(values);
        return RedirectToAction("Index");   
    }
}