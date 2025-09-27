using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.VievComponents;

public class _SkillsPartial:ViewComponent
{
    private readonly ISkillsService _skillsService;
    public _SkillsPartial(ISkillsService skillsService)
    {
        _skillsService = skillsService;
    }
    
    public IViewComponentResult Invoke()
    {
        var values = _skillsService.GetAll();
        return View(values);
    }
}