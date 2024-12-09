using AutoMapper;
using ChurchMS.Application.Features.StreetFeature.Dtos;
using ChurchMS.Domain.Entites;

namespace ChurchMS.Application.Features.StreetFeature.MappingProfiles;

public class StreetProfile : Profile
{
    public StreetProfile()
    {
        CreateMap<Street, StreetResponseDto>()
            .ReverseMap();

        CreateMap<Street, StreetRequestDto>()
            .ReverseMap();

        CreateMap<(int id, StreetRequestDto streetDto), Street>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.streetDto.Name))
            .ForMember(dest => dest.DistinctiveSign, opt => opt.MapFrom(src => src.streetDto.DistinctiveSign))
            .ForMember(dest => dest.DistrictId, opt => opt.MapFrom(src => src.streetDto.DistrictId))
            .ForAllMembers(opt => opt.UseDestinationValue());
    }
}