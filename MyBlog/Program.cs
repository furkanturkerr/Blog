using System.Globalization;
using Data_Access_Layer.Contexts;
using Business.Container;
using Entities.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using MyBlog.Hubs;
using Serilog;
using Serilog.Events;


var builder = WebApplication.CreateBuilder(args);

Extensions.ContainerDependencies(builder.Services);
builder.Services.AddControllersWithViews();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Fatal)
    .MinimumLevel.Override("System", LogEventLevel.Fatal)
    .MinimumLevel.Override("Microsoft.AspNetCore.HttpsPolicy", LogEventLevel.Fatal)
    .WriteTo.File("Logs/auth-log.txt", shared: true)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Host.UseSerilog();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials();
    });
});
builder.Services.AddSignalR();

var requireAuthorizationPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContexts>();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BlogContexts>();
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AuthorizeFilter(requireAuthorizationPolicy));
});

// ÖNEMLİ: Cookie ayarları
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/Index"; 
    options.LogoutPath = "/Login/Logout";
    options.AccessDeniedPath = "/Login";
    options.ExpireTimeSpan = TimeSpan.FromHours(1); 
    options.SlidingExpiration = true;
});

var app = builder.Build();

// Otomatik migration çalıştır
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BlogContexts>();
    db.Database.Migrate();
}

var cultures = new[] { new CultureInfo("tr-TR") };
app.UseRequestLocalization(new RequestLocalizationOptions{
    DefaultRequestCulture = new RequestCulture("tr-TR"),
    SupportedCultures = cultures,
    SupportedUICultures = cultures
});

app.UseStatusCodePages(async x =>
{
    if (x.HttpContext.Response.StatusCode == 404)
    {
        x.HttpContext.Response.Redirect("/Error/Notfount404page");
    }
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// ÖNEMLİ: Bu sıralamayı değiştirmeyin!
app.UseAuthentication(); // Kimlik doğrulama
app.UseAuthorization();  // Yetkilendirme
app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");

app.MapControllerRoute(
    name: "projeler",
    pattern: "Projeler",
    defaults: new { controller = "Default", action = "Projeler" });

app.MapControllerRoute(
    name: "ozgecmis",
    pattern: "Ozgecmis",
    defaults: new { controller = "Default", action = "Ozgecmis" });

app.MapControllerRoute(
    name: "blog",
    pattern: "Blog",
    defaults: new { controller = "Default", action = "Blog" });

app.MapControllerRoute(
    name: "iletisim",
    pattern: "Iletisim",
    defaults: new { controller = "Default", action = "Iletisim" });

app.MapControllerRoute(
    name: "anasayfa",
    pattern: "anasayfa",
    defaults: new { controller = "Default", action = "Anasayfa" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Anasayfa}/{id?}");

app.Run();