using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

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
    
    [HttpPost]
    public IActionResult Index(Service service)
    {
        if (ModelState.IsValid)
        {
            _serviceService.Update(service);
            return RedirectToAction("Index"); 
        }
        var services = _serviceService.GetAll();
        return View(services);
    }
}