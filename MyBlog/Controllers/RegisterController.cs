using Dto.IdentityDtos;
using Entities.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers;
[Authorize]
public class RegisterController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(RegisterDto registerDto)
    {
        var appUser = new AppUser()
        {
            Name = registerDto.Name,
            Surname = registerDto.Surname,
            UserName = registerDto.Username,
        };
        var result = await _userManager.CreateAsync(appUser, registerDto.Password);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Login");
        }
        
        return View();
    }
    
    [HttpGet]
    public IActionResult UserList()
    {
        var users = _userManager.Users.ToList();
        return View(users);
    }
}