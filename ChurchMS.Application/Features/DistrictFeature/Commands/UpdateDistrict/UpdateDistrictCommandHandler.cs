using ChurchMS.Application.Constants;
using ChurchMS.Application.Contracts.Mapper;
using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Application.Features.DistrictFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;
using System.Net;

namespace ChurchMS.Application.Features.DistrictFeature.Commands.UpdateDistrict;

public class UpdateDistrictCommandHandler(IDistrictRepo districtRepo, IGMapper mapper)
    : IRequestHandler<UpdateDistrictCommand, Result<DistrictResponseDto>>
{
    public async Task<Result<DistrictResponseDto>> Handle(UpdateDistrictCommand request, CancellationToken cancellationToken)
    {
        var district = await districtRepo.Get(request.Id);
        if (district == null)
            return Result<DistrictResponseDto>.Failure(HttpStatusCode.NotFound, ErrorCodes.NotFoundErrors.District);

        mapper.Map((request.Id, request.DistrictRequestDto), district);
        try
        {
            await districtRepo.Update(district);
            var districtResponseDto = mapper.Map<DistrictResponseDto>(district);

            return Result<DistrictResponseDto>.Success(districtResponseDto, HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return Result<DistrictResponseDto>.CreateException(ex);
        }
    }
}