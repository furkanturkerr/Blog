using Business.Abstract;
using Business.ValidationRules;
using Entities.Concrate;
using FluentValidation.Results;
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
        AboutValidaton aboutValidaton = new AboutValidaton();
        ValidationResult validationResult = aboutValidaton.Validate(about);
        if (validationResult.IsValid)
        {
            _abautService.Update(about);
            return RedirectToAction("Index");
        }
        else
        {
            foreach (var item in validationResult.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        return View(about);
    }
}