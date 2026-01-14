using Business.Abstract;
using Data_Access_Layer.Contexts;
using Entities.Concrate;
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
    public IActionResult Index()
    {
        var values = _blogService.GetAll();
        return View(values);
    }
    
    [HttpGet]
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
    public IActionResult Update(int id)
    {
        var values = _blogService.GetById(id);
        return View(values);
    }
    
    [HttpPost]
    public IActionResult Update(Blog blog)
    {
        _blogService.Update(blog);
        return RedirectToAction("Index");
    }
}