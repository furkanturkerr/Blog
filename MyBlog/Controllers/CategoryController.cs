using Business.Abstract;
using Business.ValidationRules;
using Entities.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public IActionResult CategoryList()
    {
        var value = _categoryService.GetAll();
        return View(value);
    }
    
    [HttpGet]
    public IActionResult CreateCategory()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateCategory(Category category)
    {
        CategoryValidation categoryValidation = new CategoryValidation();
        ValidationResult results = categoryValidation.Validate(category);
        if (results.IsValid)
        {
            _categoryService.Insert(category);
            return RedirectToAction("CategoryList");
        }
        else
        {
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        return View(category);
    }
    
    public IActionResult EditCategory(int id)
    {
        var value = _categoryService.GetById(id);
        return View(value);
    }

    [HttpPost]
    public IActionResult EditCategory(Category category)
    {
        CategoryValidation categoryValidation = new CategoryValidation();
        ValidationResult results = categoryValidation.Validate(category);
        if (results.IsValid)
        {
            _categoryService.Update(category);
            return RedirectToAction("CategoryList");
        }
        else
        {
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        return View(category);
    }

    public IActionResult DeleteCategory(int id)
    {
        
        var value = _categoryService.GetById(id);
        _categoryService.Delete(value);
        return RedirectToAction("CategoryList");
    }
}