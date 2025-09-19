using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

public class ExperinceController:Controller
{
    private IExperinceService _experinceService;
    public ExperinceController(IExperinceService experinceService)
    {
        _experinceService = experinceService;
    }
    
    
    [HttpGet]
    public IActionResult Index()
    {
        var values = _experinceService.GetAll();
        return View(values);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Experience experience)
    {
        _experinceService.Insert(experience);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult Index(Experience experience)
    {
        if (ModelState.IsValid)
        {
            _experinceService.Update(experience);
            return RedirectToAction("Index"); 
        }
        var values = _experinceService.GetAll();
        return View(values);
    }

    public IActionResult Delete(int id)
    {
        var values = _experinceService.GetById(id);
        _experinceService.Delete(values);
        return RedirectToAction("Index");   
    }
}