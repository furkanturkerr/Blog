using AutoMapper;
using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;
[AllowAnonymous]
public class DefaultController:Controller
{
    private readonly IContactService _contactService;
    public DefaultController(IContactService contactService)
    {
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
    public IActionResult Iletisim(Contact contact)
    {
        _contactService.Insert(contact);
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