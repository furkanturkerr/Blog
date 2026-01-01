using Business.Abstract;
using Business.ValidationRules;
using Entities.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;

namespace MyBlog.Controllers;

public class NavbarLeftController:Controller
{
    private INavbarLeftService _navbarLeftService;
    public NavbarLeftController(INavbarLeftService navbarLeftService)
    {
        _navbarLeftService = navbarLeftService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var values = _navbarLeftService.GetAll();
        return View(values);
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var values = _navbarLeftService.GetById(id);
        return View(values);   
    }

    [HttpPost]
    public IActionResult Update(NavbarLeft navbarLeft)
    {
        NavbarLeftValidation navbarLeftValidation = new NavbarLeftValidation();
        ValidationResult validationResult = navbarLeftValidation.Validate(navbarLeft);
        if (validationResult.IsValid)
        {
            _navbarLeftService.Update(navbarLeft);
            return RedirectToAction("Index");
        }
        else
        {
            foreach (var item in validationResult.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        return View(navbarLeft);
    }
}