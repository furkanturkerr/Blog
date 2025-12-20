using AutoMapper;
using Business.Abstract;
using Dto.Contact;
using Entities.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;
[Authorize]
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
        var values = _mapper.Map<List<ResultContactDto>>(_contactService.GetAll());
        return View(values);
    }
}