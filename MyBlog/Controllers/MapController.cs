using System.Linq;
using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;

public class MapController : Controller
{
    private readonly IMapService _mapService;

    public MapController(IMapService mapService)
    {
        _mapService = mapService;
    }

    // GET
    public IActionResult Index()
    {
        var value = _mapService.GetAll().FirstOrDefault();
        return View(value);
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var value = _mapService.GetById(id);
        return View(value);
    }

    [HttpPost]
    public IActionResult Update(Map map)
    {
        _mapService.Update(map);
        return RedirectToAction("Index");
    }
}