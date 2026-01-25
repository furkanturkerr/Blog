using System.Linq;
using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace MyBlog.ViewComponents.Thema;

public class _MapComponentPartial : ViewComponent
{
    private readonly IMapService _mapService;

    public _MapComponentPartial(IMapService mapService)
    {
        _mapService = mapService;
    }

    public ViewViewComponentResult Invoke()
    {
        var value = _mapService.GetAll().FirstOrDefault();
        return View(value);
    }
}