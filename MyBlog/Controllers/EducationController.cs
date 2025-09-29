using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

public class EducationController : Controller
{
    private readonly IEducationService _educationService;

    public EducationController(IEducationService educationService)
    {
        _educationService = educationService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var views = _educationService.GetAll();
        return View(views);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Education education)
    {
        _educationService.Insert(education);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Index(Education education)
    {
        if (ModelState.IsValid)
        {
            _educationService.Update(education);
            return RedirectToAction("Index"); 
        }

        var services = _educationService.GetAll();
        return View(services);
    }

    public IActionResult Delete(int id)
    {
        var values = _educationService.GetById(id);
        _educationService.Delete(values);
        return RedirectToAction("Index");   
    }
}