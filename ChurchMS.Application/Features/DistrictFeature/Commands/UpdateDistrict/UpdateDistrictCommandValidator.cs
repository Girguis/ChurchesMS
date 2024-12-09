using FluentValidation;

namespace ChurchMS.Application.Features.DistrictFeature.Commands.UpdateDistrict;

internal class UpdateDistrictCommandValidator : AbstractValidator<UpdateDistrictCommand>
{
    public UpdateDistrictCommandValidator()
    {
        RuleFor(x => x.DistrictRequestDto.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(255);

        RuleFor(x => x.DistrictRequestDto.CityId)
            .NotNull()
            .GreaterThan(0);
    }
}
