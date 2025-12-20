using Business.Abstract;
using Business.ValidationRules;
using Entities.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers
{
    [Authorize]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
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
        public IActionResult Add(Portfolio portfolio)
        {
            PortfolioValidation portfolioValidation = new PortfolioValidation();
            ValidationResult validationResult = portfolioValidation.Validate(portfolio);
            if (validationResult.IsValid)
            {
                _portfolioService.Insert(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        
        [HttpGet]
        public IActionResult Update(int id)
        {
            var values = _portfolioService.GetById(id);
            return View(values);
        }
        
        [HttpPost]
        public IActionResult Update(Portfolio portfolio)
        {
            PortfolioValidation portfolioValidation = new PortfolioValidation();
            ValidationResult validationResult = portfolioValidation.Validate(portfolio);
            if (validationResult.IsValid)
            {
                _portfolioService.Update(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(portfolio);
        }

        public IActionResult Delete(int id)
        {
            var values = _portfolioService.GetById(id);
            _portfolioService.Delete(values);
            return RedirectToAction("Index");
        }
    }
}
