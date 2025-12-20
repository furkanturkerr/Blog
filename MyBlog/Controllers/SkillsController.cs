using Business.Abstract;
using Business.ValidationRules;
using Entities.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;
[Authorize]
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
        var values = _skillsService.GetAll();
        return View(values);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Add(Skills skills)
    {
        SkilsValidation skilsValidation = new SkilsValidation();
        ValidationResult validationResult = skilsValidation.Validate(skills);
        if (validationResult.IsValid)
        {
            _skillsService.Insert(skills);
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
        var values = _skillsService.GetById(id);
        _skillsService.Delete(values);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Update(int id)
    {
        var values = _skillsService.GetById(id);
        return View(values);
    }
    
    [HttpPost]
    public IActionResult Update(Skills skills)
    {
        SkilsValidation skilsValidation = new SkilsValidation();
        ValidationResult validationResult = skilsValidation.Validate(skills);
        if (validationResult.IsValid)
        {
            _skillsService.Update(skills);
            return RedirectToAction("Index");
        }
        else
        {
            foreach (var item in validationResult.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        return View(skills);
    }
}