using AutoMapper;
using Business.Abstract;
using Dto.GoogleDtos;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

public class GoogleController : Controller
{
    private readonly IGoogleService _googleService;
    private readonly IMapper _mapper;
    public GoogleController(IGoogleService googleService , IMapper mapper)
    {
        _mapper = mapper;
        _googleService = googleService;
    }
    
    [HttpGet]
    public IActionResult GoogleAnalytics()
    {
        var values = _googleService.GetAll();
        return View(_mapper.Map<List<ResultGoogleAnalyticsDto>>(values));
    }
    
    [HttpGet]
    public IActionResult GoogleAnalyticsAdd()
    {
        return View();
    }

    [HttpPost]
    public IActionResult GoogleAnalyticsAdd(CreateGoogleAnalyticsDto createGoogleAnalyticsDto)
    {
        var value = _mapper.Map<Google>(createGoogleAnalyticsDto);
        _googleService.Insert(value);
        return RedirectToAction("GoogleAnalytics");
    }

    [HttpGet]
    public IActionResult GoogleAnalyticsUpdate(int id)
    {
        var value = _googleService.GetById(id);
        return View(_mapper.Map<UpdateGoogleAnalyticsDto>(value));
    }
    
    [HttpPost]
    public IActionResult GoogleAnalyticsUpdate(UpdateGoogleAnalyticsDto updateGoogleAnalyticsDto)
    {
        var value = _mapper.Map<Google>(updateGoogleAnalyticsDto);
        _googleService.Update(value);
        return RedirectToAction("GoogleAnalytics");
    }

    public IActionResult GoogleAnalyticsDelete(int id)
    {
        var values = _googleService.GetById(id);
        _googleService.Delete(values);
        return RedirectToAction("GoogleAnalytics");
    }
}