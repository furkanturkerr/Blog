using AutoMapper;
using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleMvcSitemap;

namespace MyBlog.Controllers;

[AllowAnonymous]
public class DefaultController : Controller
{
    private readonly IContactService _contactService;
    private readonly IBlogService _blogService; 
    
    public DefaultController(IContactService contactService, IBlogService blogService)
    {
        _contactService = contactService;
        _blogService = blogService;
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

    [Route("sitemap.xml")]
    public ActionResult Sitemap()
    {
        // 1. Statik Sayfalar
        var sitemapItems = new List<SitemapNode>
        {
            new SitemapNode(Url.Action("Anasayfa", "Default", null, Request.Scheme)) { ChangeFrequency = ChangeFrequency.Daily, Priority = 1.0M },
            new SitemapNode(Url.Action("Ozgecmis", "Default", null, Request.Scheme)) { ChangeFrequency = ChangeFrequency.Monthly, Priority = 0.8M },
            new SitemapNode(Url.Action("Iletisim", "Default", null, Request.Scheme)) { ChangeFrequency = ChangeFrequency.Monthly, Priority = 0.7M },
            new SitemapNode(Url.Action("Projeler", "Default", null, Request.Scheme)) { ChangeFrequency = ChangeFrequency.Weekly, Priority = 0.8M },
            new SitemapNode(Url.Action("Blog", "Default", null, Request.Scheme)) { ChangeFrequency = ChangeFrequency.Daily, Priority = 0.9M }
        };

        var blogs = _blogService.TGetListWithStatus();
        foreach (var blog in blogs)
        {
            sitemapItems.Add(new SitemapNode(Url.Action("BlogDetail", "Blog", new { blogSlug = blog.BlogSlug }, Request.Scheme))
            {
                ChangeFrequency = ChangeFrequency.Weekly,
                Priority = 0.9M,
                LastModificationDate = DateTime.Parse(blog.BlogDate).ToUniversalTime()
            });
        }

        return new SitemapProvider().CreateSitemap(new SitemapModel(sitemapItems));
    }
}