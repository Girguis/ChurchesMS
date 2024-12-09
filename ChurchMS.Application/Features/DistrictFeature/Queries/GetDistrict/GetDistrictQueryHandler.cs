using ChurchMS.Application.Constants;
using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Application.Features.DistrictFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;
using System.Net;

namespace ChurchMS.Application.Features.DistrictFeature.Queries.GetDistrict;

internal class GetDistrictQueryHandler(IDistrictRepo districtRepo)
    : IRequestHandler<GetDistrictQuery, Result<DistrictResponseDto>>
{
    private readonly IDistrictRepo _districtRepo = districtRepo;

    public async Task<Result<DistrictResponseDto>> Handle(GetDistrictQuery request, CancellationToken cancellationToken)
    {
        var district = await _districtRepo
                                .GetAsNoTracking<DistrictResponseDto>(request.Id);
        if (district == null)
            return Result<DistrictResponseDto>.Failure(HttpStatusCode.NotFound, ErrorCodes.NotFoundErrors.District);

        return Result<DistrictResponseDto>.Success(district);
    }
}
