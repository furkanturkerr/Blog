using Business.Abstract;
using Business.ValidationRules;
using Entities.Concrate;
using FluentValidation.Results;
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
        ExperincePageValidation experincePageValidation = new ExperincePageValidation();
        ValidationResult validationResult = experincePageValidation.Validate(experiencePage);
        if (validationResult.IsValid)
        {
            _experincepageService.Insert(experiencePage);
            return RedirectToAction("Index");
        }
        else
        {
            foreach (var item in validationResult.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        return View();
    }
    
    public IActionResult Delete(int id)
    {
        var values = _experincepageService.GetById(id);
        _experincepageService.Delete(values);
        return RedirectToAction("Index");   
    }
    
    [HttpGet]
    public IActionResult Update(int id)
    {
        var values = _experincepageService.GetById(id);
        return View(values);
    }

    [HttpPost]
    public IActionResult Update(ExperiencePage experiencePage)
    {
        ExperincePageValidation experincePageValidation = new ExperincePageValidation();
        ValidationResult validationResult = experincePageValidation.Validate(experiencePage);
        if (validationResult.IsValid)
        {
            _experincepageService.Update(experiencePage);
            return RedirectToAction("Index");
        }
        else
        {
            foreach (var item in validationResult.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        return View(experiencePage);
    }
}