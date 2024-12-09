using ChurchMS.Application.Constants;
using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Application.Features.StreetFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;
using System.Net;

namespace ChurchMS.Application.Features.StreetFeature.Queries.GetStreet;

public class GetStreetQueryHandler(IStreetRepo streetRepo)
    : IRequestHandler<GetStreetQuery, Result<StreetResponseDto>>
{
    private readonly IStreetRepo _streetRepo = streetRepo;

    public async Task<Result<StreetResponseDto>> Handle(GetStreetQuery request, CancellationToken cancellationToken)
    {
        var streetResponseDto = await _streetRepo.GetAsNoTracking<StreetResponseDto>(request.Id);
        if (streetResponseDto == null)
            return Result<StreetResponseDto>.Failure(HttpStatusCode.NotFound, ErrorCodes.NotFoundErrors.Street);

        return Result<StreetResponseDto>.Success(streetResponseDto);
    }
}
