using Business.Abstract;
using Microsoft.AspNetCore.SignalR;

namespace MyBlog.Hubs;

public class SignalRHub : Hub
{
    private readonly IContactService  _contactService;
    private readonly IBlogService _blogService;
    private readonly IImagesService _imagesService;
    private readonly IPortfolioService _portfolioService;

    public SignalRHub(IContactService contactService, IBlogService blogService, IImagesService imagesService, IPortfolioService portfolioService)
    {
        _contactService = contactService;
        _blogService = blogService;
        _imagesService = imagesService;
        _portfolioService = portfolioService;
    }

    public async Task SendStatistic()
    {
        var value1 = _contactService.TListFalse().Count();
        await Clients.All.SendAsync("MessageWithTrueCount", value1);
        
        var value2 = _blogService.TGetListWithStatus().Count();
        await Clients.All.SendAsync("BlogCount", value2);
        
        var value3 = _imagesService.GetAll().Count();
        await Clients.All.SendAsync("ImageCount", value3);
        
        var value4 = _portfolioService.TListStatusTrue().Count();
        await Clients.All.SendAsync("ProjeCount", value4);
    }
}