using System.Threading.Tasks;
using Entities.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MyBlog.Models;
using Serilog;

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
        var result = await _signInManager.PasswordSignInAsync(
            model.UserName,
            model.Password,
            false,
            false
        );

        if (result.Succeeded)
        {
            // ✅ BAŞARILI GİRİŞ
            Log.Information(
                "BAŞARILI GİRİŞ | Kullanıcı: {Username} | IP: {IP}",
                model.UserName,
                HttpContext.Connection.RemoteIpAddress?.ToString()
            );

            return RedirectToAction("Anasayfa", "Admin");
        }

        // ❌ BAŞARISIZ GİRİŞ
        Log.Warning(
            "BAŞARISIZ GİRİŞ | Kullanıcı: {Username} | IP: {IP}",
            model.UserName,
            HttpContext.Connection.RemoteIpAddress?.ToString()
        );

        ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        Log.Information(
            "ÇIKIŞ YAPILDI | Kullanıcı: {Username} | IP: {IP}",
            User.Identity?.Name,
            HttpContext.Connection.RemoteIpAddress?.ToString()
        );

        await _signInManager.SignOutAsync();
        return RedirectToAction("Anasayfa", "Default");
    }
}