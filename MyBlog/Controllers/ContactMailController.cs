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
}