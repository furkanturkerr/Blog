using AutoMapper;
using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

public class GoogleController : Controller
{
    private readonly IGoogleService _googleService;
    public GoogleController(IGoogleService googleService)
    {
        _googleService = googleService;
    }
    
    [HttpGet]
    public IActionResult GoogleAnalytics()
    {
        var values = _googleService.GetAll();
        return View(values);
    }
    
    [HttpGet]
    public IActionResult GoogleAnalyticsAdd()
    {
        return View();
    }

    [HttpPost]
    public IActionResult GoogleAnalyticsAdd(Google google)
    {
        _googleService.Insert(google);
        return RedirectToAction("GoogleAnalytics");
    }

    [HttpGet]
    public IActionResult GoogleAnalyticsUpdate(int id)
    {
        var value = _googleService.GetById(id);
        return View(value);
    }
    
    [HttpPost]
    public IActionResult GoogleAnalyticsUpdate(Google google)
    {
        _googleService.Update(google);
        return RedirectToAction("GoogleAnalytics");
    }

    public IActionResult GoogleAnalyticsDelete(int id)
    {
        var values = _googleService.GetById(id);
        _googleService.Delete(values);
        return RedirectToAction("GoogleAnalytics");
    }
}