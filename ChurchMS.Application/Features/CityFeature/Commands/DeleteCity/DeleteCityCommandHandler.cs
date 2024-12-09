using ChurchMS.Application.Constants;
using ChurchMS.Application.Contracts.Mapper;
using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Application.Features.CityFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;
using System.Net;

namespace ChurchMS.Application.Features.CityFeature.Commands.DeleteCity;

public class DeleteCityCommandHandler(ICityRepo cityRepo, IGMapper mapper)
    : IRequestHandler<DeleteCityCommand, Result<CityResponseDto>>
{
    private readonly ICityRepo _cityRepo = cityRepo;
    private readonly IGMapper _mapper = mapper;

    public async Task<Result<CityResponseDto>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
    {
        var city = await _cityRepo.Get(request.Id);
        if (city == null)
            return Result<CityResponseDto>.Failure(HttpStatusCode.NotFound, ErrorCodes.NotFoundErrors.City);

        try
        {
            await _cityRepo.Delete(city);
        }
        catch (Exception ex)
        {
            return Result<CityResponseDto>.CreateException(ex);
        }
        var cityResponseDto = _mapper.Map<CityResponseDto>(city);

        return Result<CityResponseDto>.Success(cityResponseDto, HttpStatusCode.Created);
    }
}