using Business.Abstract;
using Data_Access_Layer.Contexts;
using Entities.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

public class BlogController : Controller
{
    private readonly IBlogService _blogService;

    public BlogController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    [HttpGet]
    [Route("Blog/Index")]
    public IActionResult Index()
    {
        var values = _blogService.GetAll();
        return View(values);
    }
    
    
    [AllowAnonymous]
    [HttpGet("blog/{blogSlug}")]
    public IActionResult BlogDetail(string blogSlug)
    {
        var value = _blogService
            .GetAll()
            .FirstOrDefault(x => x.BlogSlug == blogSlug);

        if (value == null)
            return NotFound();

        return View(value);
    }
    
    [HttpGet]
    [Route("Blog/Add")]
    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Add(Blog blog)
    {
        blog.BlogDate = DateTime.Now.ToString();
        blog.BlogAuthor = "Furkan Türker";
        blog.BlogStatus = true;

        _blogService.Insert(blog);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var value = _blogService.GetById(id);
        _blogService.Delete(value);
        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("Blog/Update/{id}")]
    public IActionResult Update(int id)
    {
        var values = _blogService.GetById(id);
        return View(values);
    }
    
    [HttpPost]
    public IActionResult Update(Blog blog)
    {
        var value = _blogService.GetById(blog.BlogId);
        
        value.BlogTitle    = blog.BlogTitle;
        value.BlogText     = blog.BlogText;
        value.BlogImage    = blog.BlogImage;
        value.BlogCategory = blog.BlogCategory;
        value.BlogSlug     = blog.BlogSlug;
        
        _blogService.Update(value);
        return RedirectToAction("Index");
    }
}