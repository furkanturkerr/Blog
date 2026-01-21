using System.Linq;
using System.Threading.Tasks;
using Entities.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;

namespace MyBlog.Controllers;

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
    public async Task<IActionResult> Index(RegisterViewModel registerViewModel)
    {
        var appUser = new AppUser()
        {
            Name = registerViewModel.Name,
            Surname = registerViewModel.Surname,
            UserName = registerViewModel.Username,
        };
        var result = await _userManager.CreateAsync(appUser, registerViewModel.Password);
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

    public async Task<IActionResult> UserDelete()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);

        if (user == null)
            return NotFound();

        await _userManager.DeleteAsync(user);

        return RedirectToAction("UserList");
    }

    [HttpGet]
    public async Task<IActionResult> UserUpdate(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());

        var dto = new UserUpdateViewModel
        {
            Id = user.Id,
            Username = user.UserName,
            Name = user.Name,
            Surname = user.Surname,
            Mail = user.Email
        };

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> UserUpdate(UserUpdateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        var user = await _userManager.FindByIdAsync(model.Id.ToString());
        
        user.Name = model.Name;
        user.Surname = model.Surname;
        user.UserName = model.Username;
        user.Email = model.Mail;
        
        await _userManager.UpdateAsync(user);
        return RedirectToAction("UserList");
        
    }

}