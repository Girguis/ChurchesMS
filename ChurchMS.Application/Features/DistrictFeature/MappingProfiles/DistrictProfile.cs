using AutoMapper;
using ChurchMS.Application.Features.DistrictFeature.Dtos;
using ChurchMS.Domain.Entites;

namespace ChurchMS.Application.Features.DistrictFeature.MappingProfiles;

public class DistrictProfile : Profile
{
    public DistrictProfile()
    {
        CreateMap<District, DistrictResponseDto>()
            .ReverseMap();

        CreateMap<District, DistrictRequestDto>()
            .ReverseMap();

        CreateMap<(int id, DistrictRequestDto districtDto), District>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.districtDto.Name))
            .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.districtDto.CityId))
            .ForAllMembers(opt => opt.UseDestinationValue());
    }
}