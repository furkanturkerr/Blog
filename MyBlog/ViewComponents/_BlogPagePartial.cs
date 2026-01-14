using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.ViewComponents;

public class _BlogPagePartial : ViewComponent
{
    private readonly IBlogService _blogService;
    
    public _BlogPagePartial(IBlogService blogService)
    {
        _blogService = blogService;
    }
    
    public IViewComponentResult Invoke()
    {
        var values = _blogService.GetAll();
        return View(values);
    }
}