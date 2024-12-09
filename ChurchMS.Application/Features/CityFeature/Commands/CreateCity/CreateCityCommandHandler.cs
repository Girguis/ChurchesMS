using ChurchMS.Application.Contracts.Mapper;
using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Application.Features.CityFeature.Dtos;
using ChurchMS.Application.Results;
using ChurchMS.Domain.Entites;
using MediatR;
using System.Net;

namespace ChurchMS.Application.Features.CityFeature.Commands.CreateCity;

public class CreateCityCommandHandler(ICityRepo cityRepo, IGMapper mapper)
    : IRequestHandler<CreateCityCommand, Result<CityResponseDto>>
{
    private readonly ICityRepo _cityRepo = cityRepo;
    private readonly IGMapper _mapper = mapper;

    public async Task<Result<CityResponseDto>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        var city = _mapper.Map<City>(request.CityRequestDto);
        try
        {
            await _cityRepo.Create(city);
        }
        catch (Exception ex)
        {
            return Result<CityResponseDto>.CreateException(ex);
        }
        var cityResponseDto = _mapper.Map<CityResponseDto>(city);

        return Result<CityResponseDto>.Success(cityResponseDto, HttpStatusCode.Created);
    }
}