using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

public class SettingsController : Controller
{
    private readonly IWebHostEnvironment _env;

    public SettingsController(IWebHostEnvironment env)
    {
        _env = env;
    }

    public IActionResult Index()
    {
        var logPath = Path.Combine(
            _env.ContentRootPath, // 👈 PROJE KÖKÜ
            "Logs",
            "auth-log.txt"
        );

        List<string> logs = new();

        if (System.IO.File.Exists(logPath))
        {
            logs = System.IO.File
                .ReadAllLines(logPath)
                .Reverse()
                .Take(20)
                .ToList();
        }

        return View(logs);
    }
}