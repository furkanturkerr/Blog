using AutoMapper;
using Dto.AboutDto;
using Entities.Concrate;

namespace MyBlog.Mapping;

public class AboutMapping : Profile
{
    public AboutMapping()
    {
        CreateMap<About, ResultAboutDto>().ReverseMap();
        CreateMap<About, UpdateAboutDto>().ReverseMap();
        CreateMap<About, CreateAboutDto>().ReverseMap();
        CreateMap<About, GetAboutDto>().ReverseMap();
    }
}