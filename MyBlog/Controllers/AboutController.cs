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
        var about = _abautService.GetAll().FirstOrDefault()
                    ?? new Entities.Concrate.About();
        return View(about);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(Entities.Concrate.About model)
    {
        if (model.AboutId == 0) _abautService.Update(model);
        else _abautService.Update(model);

        return RedirectToAction(nameof(Index));
    }
}