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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;


var builder = WebApplication.CreateBuilder(args);

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

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/Index";
});

// ÖNEMLİ: Cookie ayarları
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login"; 
    options.LogoutPath = "/Login/Logout";
    options.AccessDeniedPath = "/Login";
    options.ExpireTimeSpan = TimeSpan.FromHours(1); 
    options.SlidingExpiration = true;
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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


var app = builder.Build();

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

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// ÖNEMLİ: Bu sıralamayı değiştirmeyin!
app.UseAuthentication(); // Kimlik doğrulama
app.UseAuthorization();  // Yetkilendirme
app.MapControllers();

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