using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;

namespace MyBlog.Controllers;

public class ImagesController : Controller
{
    private readonly IImagesService _imagesService;

    public ImagesController(IImagesService imagesService)
    {
        _imagesService = imagesService;
    }

    public IActionResult Index()
    {
        var value = _imagesService.GetAll();
        return View(value);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(ImagesViewModel model)
    {
        if (ModelState.IsValid)
        {
            string imagePath = null;
            
            if (model.Image != null)
            {
                // Orijinal dosya adını al
                var originalFileName = Path.GetFileNameWithoutExtension(model.Image.FileName);
                var extension = Path.GetExtension(model.Image.FileName);
                var imageName = originalFileName + extension;
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/upload");
                var location = Path.Combine(uploadPath, imageName);

                // Aynı isimde dosya varsa sonuna sayı ekle
                int counter = 1;
                while (System.IO.File.Exists(location))
                {
                    imageName = $"{originalFileName}_{counter}{extension}";
                    location = Path.Combine(uploadPath, imageName);
                    counter++;
                }

                using var stream = new FileStream(location, FileMode.Create);
                model.Image.CopyTo(stream);

                imagePath = "/img/upload/" + imageName;
            }

            // Entity oluştur
            var imageEntity = new Images
            {
                Image = imagePath
            };

            _imagesService.Insert(imageEntity);
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var value = _imagesService.GetById(id);
        if (value == null)
        {
            return RedirectToAction("Index");
        }

        var model = new ImagesViewModel
        {
            ImagesId = value.ImagesId,
            ImagePath = value.Image
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Update(ImagesViewModel model)
    {
        if (ModelState.IsValid)
        {
            string imagePath = model.ImagePath; // Eski yolu koru

            if (model.Image != null)
            {
                // Orijinal dosya adını al
                var originalFileName = Path.GetFileNameWithoutExtension(model.Image.FileName);
                var extension = Path.GetExtension(model.Image.FileName);
                var imageName = originalFileName + extension;
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/upload");
                var location = Path.Combine(uploadPath, imageName);

                // Aynı isimde dosya varsa sonuna sayı ekle
                int counter = 1;
                while (System.IO.File.Exists(location))
                {
                    imageName = $"{originalFileName}_{counter}{extension}";
                    location = Path.Combine(uploadPath, imageName);
                    counter++;
                }

                using var stream = new FileStream(location, FileMode.Create);
                model.Image.CopyTo(stream);

                imagePath = "/img/upload/" + imageName;
            }

            // Entity güncelle
            var imageEntity = new Images
            {
                ImagesId = model.ImagesId,
                Image = imagePath
            };

            _imagesService.Update(imageEntity);
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Delete(int id)
    {
        var value = _imagesService.GetById(id);
        if (value != null)
        {
            _imagesService.Delete(value);
        }
        return RedirectToAction("Index");
    }
}