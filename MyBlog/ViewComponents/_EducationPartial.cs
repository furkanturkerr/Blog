using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.ViewComponents;

public class _EducationPartial:ViewComponent
{
    private readonly IEducationService _educationService;
    public _EducationPartial(IEducationService educationService)
    {
        _educationService = educationService;
    }
    public IViewComponentResult Invoke()
    {
        var values = _educationService.GetAll();
        return View(values);
    }
}