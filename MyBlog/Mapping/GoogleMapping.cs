using AutoMapper;
using Dto.GoogleDtos;
using Entities.Concrate;

namespace MyBlog.Mapping;

public class GoogleMapping : Profile
{
    public GoogleMapping ()
    {
        CreateMap<Google, ResultGoogleAnalyticsDto>().ReverseMap();
        CreateMap<Google, CreateGoogleAnalyticsDto>().ReverseMap();
        CreateMap<Google, UpdateGoogleAnalyticsDto>().ReverseMap();
        CreateMap<Google, GetGoogleAnalyticsDto>().ReverseMap();
    }
}