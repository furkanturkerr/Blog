using Business.Abstract;
using Business.ValidationRules;
using Entities.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;
[Authorize]
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
        var vievs = _educationService.GetAll();
        return View(vievs);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Education education)
    {
        EducationValidation experincePageValidation = new EducationValidation();
        ValidationResult validationResult = experincePageValidation.Validate(education);
        if (validationResult.IsValid)
        {
            _educationService.Insert(education);
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
        var values = _educationService.GetById(id);
        _educationService.Delete(values);
        return RedirectToAction("Index");   
    }
    
    [HttpGet]
    public IActionResult Update(int id)
    {
        var values = _educationService.GetById(id);
        return View(values);
    }

    [HttpPost]
    public IActionResult Update(Education education)
    {
       EducationValidation experincePageValidation = new EducationValidation();
        ValidationResult validationResult = experincePageValidation.Validate(education);
        if (validationResult.IsValid)
        {
            _educationService.Update(education);
            return RedirectToAction("Index");
        }
        else
        {
            foreach (var item in validationResult.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        return View(education);
    }
}