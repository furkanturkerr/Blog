using AutoMapper;
using Business.Abstract;
using Business.ValidationRules;
using Dto.Portfolio;
using Entities.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers
{
    
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IMapper _mapper;

        public PortfolioController(IPortfolioService portfolioService, IMapper mapper)
        {
            _portfolioService = portfolioService;
            _mapper = mapper;
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
        public IActionResult Add(CreatePortfolioDto createPortfolioDto)
        {
            if (createPortfolioDto == null)
            {
                return View();
            }

            CreatePortfolioValidation createPortfolioValidation = new CreatePortfolioValidation();
            ValidationResult validationResult = createPortfolioValidation.Validate(createPortfolioDto);
            if (validationResult.IsValid)
            {
                if (createPortfolioDto.PortfolioImage != null)
                {
                    var extension = Path.GetExtension(createPortfolioDto.PortfolioImage.FileName);
                    var imageName = Guid.NewGuid().ToString() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/upload", imageName);

                    using var stream = new FileStream(location, FileMode.Create);
                    createPortfolioDto.PortfolioImage.CopyTo(stream);

                    createPortfolioDto.PortfolioImagePath = "/img/upload/" + imageName;
                }
                var value = _mapper.Map<Portfolio>(createPortfolioDto);
                _portfolioService.Insert(value);
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
            if (values == null)
            {
                return RedirectToAction("Index");
            }

            var dto = _mapper.Map<UpdatePortfolioDto>(values);
            return View(dto);
        }
        
        [HttpPost]
        public IActionResult Update(UpdatePortfolioDto updatePortfolioDto)
        {
            if (updatePortfolioDto == null)
            {
                return View();
            }
            
            UpdatePortfolioValidation updatePortfolioValidation = new UpdatePortfolioValidation();
            ValidationResult validationResult = updatePortfolioValidation.Validate(updatePortfolioDto);
            if (validationResult.IsValid)
            {
                // Yeni görsel yüklendiyse işle
                if (updatePortfolioDto.PortfolioImage != null)
                {
                    var extension = Path.GetExtension(updatePortfolioDto.PortfolioImage.FileName);
                    var imageName = Guid.NewGuid().ToString() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/upload", imageName);

                    using var stream = new FileStream(location, FileMode.Create);
                    updatePortfolioDto.PortfolioImage.CopyTo(stream);

                    updatePortfolioDto.PortfolioImagePath = "/img/upload/" + imageName;
                }
                // Yeni görsel yoksa, eski görseli koru (PortfolioImagePath zaten dolu gelir)

                var value = _mapper.Map<Portfolio>(updatePortfolioDto);
                _portfolioService.Update(value);
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

        public IActionResult Delete(int id)
        {
            var values = _portfolioService.GetById(id);
            _portfolioService.Delete(values);
            return RedirectToAction("Index");
        }
    }
}
