using ChurchMS.Application.Constants;
using ChurchMS.Application.Contracts.Mapper;
using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Application.Features.DistrictFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;
using System.Net;

namespace ChurchMS.Application.Features.DistrictFeature.Commands.DeleteDistrict;

public class DeleteDistrictCommandHandler(IDistrictRepo districtRepo, IGMapper mapper)
    : IRequestHandler<DeleteDistrictCommand, Result<DistrictResponseDto>>
{
    private readonly IDistrictRepo _districtRepo = districtRepo;
    private readonly IGMapper _mapper = mapper;

    public async Task<Result<DistrictResponseDto>> Handle(DeleteDistrictCommand request, CancellationToken cancellationToken)
    {
        var district = await _districtRepo.Get(request.Id);
        if (district == null)
            return Result<DistrictResponseDto>.Failure(HttpStatusCode.NotFound, ErrorCodes.NotFoundErrors.District);

        try
        {
            await _districtRepo.Delete(district);
        }
        catch (Exception ex)
        {
            return Result<DistrictResponseDto>.CreateException(ex);
        }
        var districtResponseDto = _mapper.Map<DistrictResponseDto>(district);

        return Result<DistrictResponseDto>.Success(districtResponseDto, HttpStatusCode.Created);
    }
}