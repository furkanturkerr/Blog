using AutoMapper;
using Dto.Portfolio;
using Entities.Concrate;

namespace MyBlog.Mapping;

public class PortfolioMapping : Profile
{
    public PortfolioMapping()
    {
        // Create (Add) için mapping
        CreateMap<CreatePortfolioDto, Portfolio>()
            .ForMember(dest => dest.PortfolioImage,
                opt => opt.MapFrom(src => src.PortfolioImagePath));

        // Update için DTO → Entity
        CreateMap<UpdatePortfolioDto, Portfolio>()
            .ForMember(dest => dest.PortfolioImage,
                opt => opt.MapFrom(src => src.PortfolioImagePath));

        // Update için Entity → DTO
        CreateMap<Portfolio, UpdatePortfolioDto>()
            .ForMember(dest => dest.PortfolioImagePath,
                opt => opt.MapFrom(src => src.PortfolioImage))
            .ForMember(dest => dest.PortfolioImage,
                opt => opt.Ignore());
    }
}