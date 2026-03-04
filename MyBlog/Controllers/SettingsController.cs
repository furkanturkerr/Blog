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
            _env.ContentRootPath,
            "Logs",
            "auth-log.txt"
        );

        List<string> logs = new();

        try
        {
            if (System.IO.File.Exists(logPath))
            {
                using var stream = new FileStream(
                    logPath,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.ReadWrite);

                using var reader = new StreamReader(stream);

                logs = reader
                    .ReadToEnd()
                    .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                    // sadece AUTH loglarını dahil et
                    .Where(x => x.Contains("AUTH |"))
                    .Reverse()
                    .Take(20)
                    .ToList();
            }
        }
        catch (Exception ex)
        {
            logs.Add("LOG OKUMA HATASI: " + ex.Message);
        }

        return View(logs);
    }
    
    [HttpPost]
    public IActionResult ClearLogs()
    {
        var logPath = Path.Combine(
            _env.ContentRootPath,
            "Logs",
            "auth-log.txt"
        );

        if (System.IO.File.Exists(logPath))
        {
            using var stream = new FileStream(
                logPath,
                FileMode.Truncate,   
                FileAccess.Write,
                FileShare.ReadWrite
            );
        }

        return RedirectToAction("Index");
    }


}