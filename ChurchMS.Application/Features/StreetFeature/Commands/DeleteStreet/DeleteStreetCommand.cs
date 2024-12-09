using ChurchMS.Application.Features.StreetFeature.Dtos;
using ChurchMS.Application.Results;
using MediatR;

namespace ChurchMS.Application.Features.StreetFeature.Commands.DeleteStreet;

public class DeleteStreetCommand : IRequest<Result<StreetResponseDto>>
{
    public int Id { get; set; }
}