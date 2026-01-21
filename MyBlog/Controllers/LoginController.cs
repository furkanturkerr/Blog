using System.Threading.Tasks;
using Entities.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MyBlog.Models;

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
    public async Task<IActionResult> Index(LoginViewModel model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
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
        return RedirectToAction("Anasayfa", "Default");
    }
}