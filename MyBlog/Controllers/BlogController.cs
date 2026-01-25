using Business.Abstract;
using Data_Access_Layer.Contexts;
using Entities.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyBlog.Controllers;

public class BlogController : Controller
{
    private readonly IBlogService _blogService;
    private readonly ICategoryService _categoryService;

    public BlogController(IBlogService blogService, ICategoryService categoryService)
    {
        _blogService = blogService;
        _categoryService = categoryService;
    }

    [HttpGet]
    [Route("Blog/Index")]
    public IActionResult Index()
    {
        var values = _blogService.TGetListWithCategory();
        return View(values);
    }
    
    
    [AllowAnonymous]
    [HttpGet("blog/{blogSlug}")]
    public IActionResult BlogDetail(string blogSlug)
    {
        var value = _blogService
            .TGetListWithCategory()
            .FirstOrDefault(x => x.BlogSlug == blogSlug);

        if (value == null)
            return NotFound();

        return View(value);
    }
    
    [HttpGet]
    [Route("Blog/Add")]
    public IActionResult Add()
    {
        ViewBag.Categories = new SelectList(
            _categoryService.GetAll(),
            "CategoryId",
            "CategoryName"
        );
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
        ViewBag.Categories = new SelectList(
            _categoryService.GetAll(),
            "CategoryId",
            "CategoryName",
            values.CategoryId
        );
        return View(values);
    }
    
    [HttpPost]
    public IActionResult Update(Blog blog)
    {
        var value = _blogService.GetById(blog.BlogId);
        
        value.BlogTitle    = blog.BlogTitle;
        value.BlogText     = blog.BlogText;
        value.BlogImage    = blog.BlogImage;
        value.CategoryId = blog.CategoryId;
        value.BlogSlug     = blog.BlogSlug;
        
        _blogService.Update(value);
        return RedirectToAction("Index");
    }
}