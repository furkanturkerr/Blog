using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.ViewComponents.Thema;

public class _BlogCategoryComponentPartial : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public _BlogCategoryComponentPartial(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _categoryService.GetAll();
        return View(values);
    }
}