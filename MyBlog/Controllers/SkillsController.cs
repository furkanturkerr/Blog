using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

public class SkillsController:Controller
{
    private readonly ISkillsService _skillsService;

    public SkillsController(ISkillsService skillsService)
    {
        _skillsService = skillsService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var services = _skillsService.GetAll();
        return View(services);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Skills skills)
    {
        if (ModelState.IsValid)
        {
            _skillsService.Insert(skills);
            return RedirectToAction("Index");
        }
        return View();
    }
    
    [HttpPost]
    public IActionResult Index(Skills service)
    {
        if (ModelState.IsValid)
        {
            _skillsService.Update(service);
            return RedirectToAction("Index"); 
        }
        var services = _skillsService.GetAll();
        return View(services);
    }
    
    public IActionResult Delete(int id)
    {
        var values = _skillsService.GetById(id);
        _skillsService.Delete(values);
        return RedirectToAction("Index");   
    }
}