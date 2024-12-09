using ChurchMS.Application.Features.CityFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;

namespace ChurchMS.Application.Features.CityFeature.Queries.GetAllCities;

public record GetAllCitiesQuery : IRequest<Result<List<CityResponseDto>>>;