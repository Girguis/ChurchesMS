using ChurchMS.Application.Common.Dtos.Request.Filters;
using ChurchMS.Application.Common.Dtos.Response;
using ChurchMS.Application.Features.StreetFeature.Commands.CreateStreet;
using ChurchMS.Application.Features.StreetFeature.Commands.DeleteStreet;
using ChurchMS.Application.Features.StreetFeature.Commands.UpdateStreet;
using ChurchMS.Application.Features.StreetFeature.Dtos;
using ChurchMS.Application.Features.StreetFeature.Queries.GetFilteredStreets;
using ChurchMS.Application.Features.StreetFeature.Queries.GetStreet;
using ChurchMS.Domain.Common.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChurchMS.API.Controllers;

public class StreetsController(IMediator mediator) : BaseController
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(PagedResult<StreetResponseDto>))]
    [ProducesResponseType(500)]
    [HasPermission(PermissionsEnum.GetStreet)]
    public async Task<IActionResult> Get([FromQuery] QueryDto queryDto)
    {
        var result = await _mediator.Send(new GetFilteredStreetsQuery()
        {
            QueryDto = queryDto
        });

        return result.ToActionResult();
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(200, Type = typeof(StreetResponseDto))]
    [ProducesResponseType(404, Type = typeof(ErrorDto))]
    [ProducesResponseType(500)]
    [HasPermission(PermissionsEnum.GetStreet)]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetStreetQuery()
        {
            Id = id
        });

        return result.ToActionResult();
    }

    [HttpPost]
    [ProducesResponseType(201, Type = typeof(StreetResponseDto))]
    [ProducesResponseType(400, Type = typeof(ErrorDto))]
    [ProducesResponseType(500)]
    [HasPermission(PermissionsEnum.CreateCity)]
    public async Task<IActionResult> Create(StreetRequestDto streetRequestDto)
    {
        var result = await _mediator.Send(new CreateStreetCommand()
        {
            StreetRequestDto = streetRequestDto
        });

        return result.ToActionResult();
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(200, Type = typeof(StreetResponseDto))]
    [ProducesResponseType(400, Type = typeof(ErrorDto))]
    [ProducesResponseType(404, Type = typeof(ErrorDto))]
    [ProducesResponseType(500)]
    [HasPermission(PermissionsEnum.UpdateStreet)]
    public async Task<IActionResult> Update(int id, StreetRequestDto streetRequestDto)
    {
        var result = await _mediator.Send(new UpdateStreetCommand()
        {
            Id = id,
            StreetRequestDto = streetRequestDto
        });

        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(200, Type = typeof(StreetResponseDto))]
    [ProducesResponseType(404, Type = typeof(ErrorDto))]
    [ProducesResponseType(500)]
    [HasPermission(PermissionsEnum.DeleteStreet)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteStreetCommand()
        {
            Id = id
        });

        return result.ToActionResult();
    }
}