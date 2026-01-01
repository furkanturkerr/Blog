using AutoMapper;
using Business.Abstract;
using Business.ValidationRules;
using Dto.AboutDto;
using Entities.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

public class AboutController:Controller
{
    private readonly IAbautService _abautService;
    private readonly IMapper _mapper;
    public AboutController(IAbautService abautService , IMapper mapper)
    {
        _mapper = mapper;
        _abautService = abautService;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var values = _abautService.GetAll();
        var dtoList = _mapper.Map<List<ResultAboutDto>>(values);
        return View(dtoList);
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var value = _abautService.GetById(id);
        var dto = _mapper.Map<UpdateAboutDto>(value);
        return View(dto);
    }
    
    [HttpPost]
    public IActionResult Update(UpdateAboutDto updateAboutDto)
    {
        AboutValidaton aboutValidaton = new AboutValidaton();
        ValidationResult validationResult = aboutValidaton.Validate(updateAboutDto);
        if (validationResult.IsValid)
        {
            var value = _mapper.Map<About>(updateAboutDto);
            _abautService.Update(value);
            return RedirectToAction("Index");
        }
        else
        {
            foreach (var item in validationResult.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
        }
        return View(updateAboutDto);
    }
}