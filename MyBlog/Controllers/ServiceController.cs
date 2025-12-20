using Business.Abstract;
using Business.ValidationRules;
using Entities.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;
[Authorize]
public class ServiceController:Controller
{
    private readonly IServiceService _serviceService;
    public ServiceController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var services = _serviceService.GetAll();
        return View(services);
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var services = _serviceService.GetById(id);
        return View(services);
    }
    
    [HttpPost]
    public IActionResult Update(Service service)
    {
        ServiceValidation serviceValidation = new ServiceValidation();
        ValidationResult validationResult = serviceValidation.Validate(service);
        if (validationResult.IsValid)
        {
            _serviceService.Update(service);
            return RedirectToAction("Index"); 
        }
        else
        {
            foreach (var item in validationResult.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        return View(service);
    }
}