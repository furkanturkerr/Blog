using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

public class AboutController:Controller
{
    private readonly IAbautService _abautService;
    public AboutController(IAbautService abautService)
    {
        _abautService = abautService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var values = _abautService.GetAll();
        return View(values);
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var values = _abautService.GetById(id);
        return View(values);
    }
    
    [HttpPost]
    public IActionResult Update(About about)
    {
        _abautService.Update(about);
        return RedirectToAction("Index");
    }
}