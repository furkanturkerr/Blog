using Business.Abstract;
using Business.Concrate;
using Data_Access_Layer.Abstract;
using Data_Access_Layer.Concrate.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Container;

public class Extensions
{
    public static void ContainerDependencies(IServiceCollection services)
    {
        services.AddScoped<IAbautService, AbautManager>();
        services.AddScoped<IAbautDal, EfAbautDal>();
        services.AddScoped<IServiceService, ServiceManager>();
        services.AddScoped<IServiceDal, EfServiceDal>();
        services.AddScoped<IExperinceService, ExperinceManager>();
        services.AddScoped<IExperinceDal, EfExperinceDal>();
        services.AddScoped<INavbarLeftService, NavbarLeftManager>();
        services.AddScoped<INavbarLeftDal, EfNavbarDal>();
        services.AddScoped<ISkilsDal, EfSkilsDal>();
        services.AddScoped<ISkillsService, SkillsManager>();
        services.AddScoped<IExperincePageService, ExperincePageManager>();
        services.AddScoped<IExprenicePageDal, EfExprenicePageDal>();
        services.AddScoped<IEducationService, EducationManager>();
        services.AddScoped<IEducationDal, EfEducationDal>();
        services.AddScoped<IPortfolioService, PortfolioManager>();
        services.AddScoped<IPortfolioDal, EfPortfolioDal>();
        services.AddScoped<IGoogleService, GoogleManager>();
        services.AddScoped<IGoogleDal, EfGoogleDal>();
        services.AddScoped<IContactService, ContactManager>();
        services.AddScoped<IContactDal, EfContactDal>();
        services.AddScoped<IBlogService, BlogManager>();
        services.AddScoped<IBlogDal, EfBlogDal>();
        services.AddScoped<IImagesDal, EfImagesDal>();
        services.AddScoped<IImagesService, ImagesManager>();
        services.AddScoped<IMapService, MapManager>();
        services.AddScoped<IMapDal, EfMapDal>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<ICategoryDal, EfCategoryDal>();
    }
}