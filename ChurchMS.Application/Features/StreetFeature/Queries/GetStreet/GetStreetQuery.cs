using ChurchMS.Application.Features.StreetFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;

namespace ChurchMS.Application.Features.StreetFeature.Queries.GetStreet;

public class GetStreetQuery : IRequest<Result<StreetResponseDto>>
{
    public int Id { get; set; }
}
