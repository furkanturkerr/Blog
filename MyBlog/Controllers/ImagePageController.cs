using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;
[Authorize]

public class ImagePageController : Controller
{
    private readonly IImagePageService _imagePageService;
    private readonly IWebHostEnvironment _env;

    public ImagePageController(IImagePageService imagePageService, IWebHostEnvironment env)
    {
        _imagePageService = imagePageService;
        _env = env;
    }

    // Liste
    public IActionResult Index(string q)
    {
        var values = _imagePageService.GetAll();

        if (!string.IsNullOrWhiteSpace(q))
        {
            q = q.Trim().ToLowerInvariant();
            values = values
                .Where(x =>
                    (x.FileName ?? "").ToLower().Contains(q) ||
                    (x.Title ?? "").ToLower().Contains(q) ||
                    (x.AltText ?? "").ToLower().Contains(q) ||
                    (x.Keywords ?? "").ToLower().Contains(q))
                .ToList();
        }

        return View(values.OrderByDescending(x => x.UploadDate).ToList());
    }

    // Ekle (GET)
    [HttpGet]
    public IActionResult AddImage() => View();

    // Ekle (POST) – tek dosya
    [HttpPost]
    public async Task<IActionResult> AddImage(IFormFile file, ImagesPage image)
    {
        if (file == null || file.Length == 0)
        {
            ModelState.AddModelError("", "Lütfen bir görsel seçin.");
            return View(image);
        }

        string folder = Path.Combine(_env.WebRootPath, "images");
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        string ext = Path.GetExtension(file.FileName);
        string unique = $"{Guid.NewGuid()}{ext}";
        string absPath = Path.Combine(folder, unique);

        using (var fs = new FileStream(absPath, FileMode.Create))
            await file.CopyToAsync(fs);

        image.FileName = file.FileName;
        image.FilePath = "/images/" + unique;
        image.FileType = file.ContentType;
        image.FileSize = file.Length;
        image.UploadDate = DateTime.UtcNow;
        image.IsActive = true;

        // İlk değerler boşsa otomatik üret (dosya adından)
        if (string.IsNullOrWhiteSpace(image.Title))
            image.Title = Path.GetFileNameWithoutExtension(file.FileName);

        if (string.IsNullOrWhiteSpace(image.SeoSlug))
            image.SeoSlug = ToSlug(image.Title);

        if (string.IsNullOrWhiteSpace(image.AltText))
            image.AltText = image.Title;

        _imagePageService.Insert(image);
        return RedirectToAction(nameof(Index));
    }

    // Satır içi SEO güncelle
    [HttpPost]
    public IActionResult UpdateSeo(int id, string altText, string title, string seoSlug, string description, string keywords, bool isActive = true)
    {
        var img = _imagePageService.GetById(id);
        if (img == null) return NotFound();

        img.AltText = altText?.Trim();
        img.Title = title?.Trim();
        img.SeoSlug = string.IsNullOrWhiteSpace(seoSlug) ? ToSlug(title) : seoSlug.Trim();
        img.Description = description?.Trim();
        img.Keywords = keywords?.Trim();
        img.IsActive = isActive;

        _imagePageService.Update(img);
        return RedirectToAction(nameof(Index));
    }

    // Sil
    public IActionResult Delete(int id)
    {
        var img = _imagePageService.GetById(id);
        if (img != null)
            _imagePageService.Delete(img);
        return RedirectToAction(nameof(Index));
    }

    // Basit slug helper
    private static string ToSlug(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return null;
        string s = input.ToLowerInvariant();

        // Türkçe karakterleri dönüştür
        s = s.Replace("ı", "i").Replace("ğ", "g").Replace("ü", "u")
             .Replace("ş", "s").Replace("ö", "o").Replace("ç", "c");

        // alfasayısal dışını tire yap
        s = System.Text.RegularExpressions.Regex.Replace(s, @"[^a-z0-9]+", "-")
             .Trim('-');

        return s;
    }
}
