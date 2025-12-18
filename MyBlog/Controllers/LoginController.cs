using Dto.IdentityDtos;
using Entities.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace MyBlog.Controllers;
[AllowAnonymous]
public class LoginController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;

    public LoginController(SignInManager<AppUser> signInManager)
    {
        _signInManager = signInManager;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginDto loginDto)
    {
        var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);
        if (!result.Succeeded)
        {
            return RedirectToAction("Index", "AdminHome");
        }

        return View();
    }
    
    [HttpGet]
    public IActionResult Logout()
    {
        _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Default");
    }
}