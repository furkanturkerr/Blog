using Business.Abstract;
using Business.ValidationRules;
using Entities.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;

namespace MyBlog.Controllers;
[Authorize]
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
        ExperinceValidation experinceValidation = new ExperinceValidation();
        ValidationResult validationResult = experinceValidation.Validate(experience);
        if (validationResult.IsValid)
        {
            _experinceService.Insert(experience);
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
        var values = _experinceService.GetById(id);
        _experinceService.Delete(values);
        return RedirectToAction("Index");   
    }
}