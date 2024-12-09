using AutoMapper;
using ChurchMS.Application.Common.Dtos.Request.Filters;
using ChurchMS.Application.Features.CityFeature.Dtos;
using ChurchMS.Application.Features.CityFeature.Queries.GetFilteredCities;
using ChurchMS.Domain.Entites;

namespace ChurchMS.Application.Features.CityFeature.MappingProfiles;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<City, CityResponseDto>()
            .ReverseMap();

        CreateMap<City, CityRequestDto>()
            .ReverseMap();

        CreateMap<QueryDto, GetFilteredCitiesQuery>();

        CreateMap<(int id, CityRequestDto cityDto), City>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.cityDto.Name))
            .ForAllMembers(opt => opt.UseDestinationValue());
    }
}