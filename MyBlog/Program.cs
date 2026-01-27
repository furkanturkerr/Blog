using System;
using System.Globalization;
using System.Reflection;
using Business.Abstract;
using Business.Concrate;
using Data_Access_Layer.Abstract;
using Data_Access_Layer.Concrate.EntityFramework;
using Data_Access_Layer.Contexts;
using Entities.Concrate;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBlog.Hubs;
using Serilog;
using Serilog.Events;


var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddScoped<IAbautService, AbautManager>();
builder.Services.AddScoped<IAbautDal, EfAbautDal>();
builder.Services.AddScoped<IServiceService, ServiceManager>();
builder.Services.AddScoped<IServiceDal, EfServiceDal>();
builder.Services.AddScoped<IExperinceService, ExperinceManager>();
builder.Services.AddScoped<IExperinceDal, EfExperinceDal>();
builder.Services.AddScoped<INavbarLeftService, NavbarLeftManager>();
builder.Services.AddScoped<INavbarLeftDal, EfNavbarDal>();
builder.Services.AddScoped<ISkilsDal, EfSkilsDal>();
builder.Services.AddScoped<ISkillsService, SkillsManager>();
builder.Services.AddScoped<IExperincePageService, ExperincePageManager>();
builder.Services.AddScoped<IExprenicePageDal, EfExprenicePageDal>();
builder.Services.AddScoped<IEducationService, EducationManager>();
builder.Services.AddScoped<IEducationDal, EfEducationDal>();
builder.Services.AddScoped<IPortfolioService, PortfolioManager>();
builder.Services.AddScoped<IPortfolioDal, EfPortfolioDal>();
builder.Services.AddScoped<IGoogleService, GoogleManager>();
builder.Services.AddScoped<IGoogleDal, EfGoogleDal>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IBlogService, BlogManager>();
builder.Services.AddScoped<IBlogDal, EfBlogDal>();
builder.Services.AddScoped<IImagesDal, EfImagesDal>();
builder.Services.AddScoped<IImagesService, ImagesManager>();
builder.Services.AddScoped<IMapService, MapManager>();
builder.Services.AddScoped<IMapDal, EfMapDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();


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