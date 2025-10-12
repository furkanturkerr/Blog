using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PortfolioController(IPortfolioService portfolioService, IWebHostEnvironment webHostEnvironment)
        {
            _portfolioService = portfolioService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var views = _portfolioService.GetAll();
            return View(views);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Portfolio portfolio, IFormFile? PortfolioImageFile)
        {
            if (PortfolioImageFile != null && PortfolioImageFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "portfolio");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + PortfolioImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await PortfolioImageFile.CopyToAsync(fileStream);
                }

                portfolio.PortfolioImage = "/portfolio/" + uniqueFileName;
            }
            else
            {
                if (string.IsNullOrEmpty(portfolio.PortfolioImage))
                {
                    portfolio.PortfolioImage = null; 
                }
            }

            _portfolioService.Insert(portfolio);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Index(Portfolio portfolio, IFormFile? PortfolioImageFile)
        {
            if (PortfolioImageFile != null && PortfolioImageFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "portfolio");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + PortfolioImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await PortfolioImageFile.CopyToAsync(fileStream);
                }

                portfolio.PortfolioImage = "/portfolio/" + uniqueFileName;
            }
            else
            {
                // Eski resmi koru
                var existing = _portfolioService.GetById(portfolio.PortfolioId);
                portfolio.PortfolioImage = existing.PortfolioImage;
            }

            _portfolioService.Update(portfolio);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var values = _portfolioService.GetById(id);
            _portfolioService.Delete(values);
            return RedirectToAction("Index");
        }
    }
}
