using AutoMapper;
using Business.Abstract;
using Dto.Contact;
using Entities.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;
[AllowAnonymous]
public class DefaultController:Controller
{
    private readonly IContactService _contactService;
    private readonly IMapper _mapper;
    public DefaultController(IContactService contactService , IMapper mapper)
    {
        _mapper = mapper;
        _contactService = contactService;
    }
    
    public IActionResult Anasayfa()
    {
        return View();
    }
    
    public IActionResult Ozgecmis()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult Iletisim()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Iletisim(CreateContactDto createContactDto)
    {
        var value = _mapper.Map<Contact>(createContactDto);
        _contactService.Insert(value);
        TempData["Basarili"] = "Mesajınız alındı, teşekkürler!";
        return RedirectToAction("Iletisim");
    }
    
    public IActionResult Blog()
    {
        return View();
    }

    public IActionResult Projeler()
    {
        return View();
    }
}