using AutoMapper;
using Business.Abstract;
using Dto.Contact;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

public class ContactMailController : Controller
{
    private readonly IContactService  _contactService;
    private readonly IMapper _mapper;
    public ContactMailController(IContactService contactService,  IMapper mapper)
    {
        _contactService = contactService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var values = _contactService.GetAll();

        var sortedValues = values
            .OrderByDescending(x => x.ContactId)
            .ToList();

        var dtoList = _mapper.Map<List<ResultContactDto>>(sortedValues);

        return View(dtoList);
    }
    
    [HttpGet]
    public IActionResult Detail(int id)
    {
        var values = _contactService.GetById(id);
        return View(_mapper.Map<ResultContactDto>(values));
    }
    
    [HttpGet]
    public IActionResult Unread(int id)
    {
        var values = _contactService.TListFalse();
        var sortedValues = values
            .OrderByDescending(x => x.ContactId)
            .ToList();
        return View(_mapper.Map<List<ResultContactDto>>(sortedValues));
    }
    
    [HttpGet]
    public IActionResult Read(int id)
    {
        var values = _contactService.TListTrue();
        var sortedValues = values
            .OrderByDescending(x => x.ContactId)
            .ToList();
        return View(_mapper.Map<List<ResultContactDto>>(sortedValues));
    }

    public IActionResult ChangeStatusTrue(int id)
    {
        _contactService.TChageStatusWithTrue(id);
        return RedirectToAction("Unread");
    }
    
    public IActionResult ChangeStatusFalse(int id)
    {
        _contactService.TChageStatusWithFalse(id);
        return RedirectToAction("Read");
    }
    
    public IActionResult Delete(int id)
    {
        var values = _contactService.GetById(id);
        _contactService.Delete(values);
        return RedirectToAction("Unread");   
    }
}