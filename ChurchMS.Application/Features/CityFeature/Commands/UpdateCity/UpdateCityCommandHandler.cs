using ChurchMS.Application.Constants;
using ChurchMS.Application.Contracts.Mapper;
using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Application.Features.CityFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;
using System.Net;

namespace ChurchMS.Application.Features.CityFeature.Commands.UpdateCity;

public class UpdateCityCommandHandler(ICityRepo cityRepo, IGMapper mapper)
    : IRequestHandler<UpdateCityCommand, Result<CityResponseDto>>
{
    public async Task<Result<CityResponseDto>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        var city = await cityRepo.Get(request.Id);
        if (city == null)
            return Result<CityResponseDto>.Failure(HttpStatusCode.NotFound, ErrorCodes.NotFoundErrors.City);

        mapper.Map((request.Id, request.CityRequestDto), city);
        try
        {
            await cityRepo.Update(city);
            var cityResponseDto = mapper.Map<CityResponseDto>(city);

            return Result<CityResponseDto>.Success(cityResponseDto, HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return Result<CityResponseDto>.CreateException(ex);
        }
    }
}