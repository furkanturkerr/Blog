using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;

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
    public IActionResult Add(ExperinceViewModel experience)
    {
        Experience w = new Experience();
        if (experience.ExperiencImage != null)
        {
            var extention = Path.GetExtension(experience.ExperiencImage.FileName);
            var newimageName = Guid.NewGuid().ToString() + extention;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/experiences", newimageName);
            var stream = new FileStream(location, FileMode.Create);
            experience.ExperiencImage.CopyTo(stream);
            w.ExperiencImage = newimageName;
        }
        _experinceService.Insert(w);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult Index(ExperinceViewModel experience)
    {
        Experience w = _experinceService.GetById(experience.ExperienceId);
        if (experience.ExperiencImage != null)
        {
            var extention = Path.GetExtension(experience.ExperiencImage.FileName);
            var newimageName = Guid.NewGuid().ToString() + extention;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/experiences", newimageName);
            var stream = new FileStream(location, FileMode.Create);
            experience.ExperiencImage.CopyTo(stream);
            w.ExperiencImage = newimageName;
        }
        _experinceService.Update(w);
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