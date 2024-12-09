using FluentValidation;

namespace ChurchMS.Application.Features.DistrictFeature.Commands.CreateDistrict;

internal class CreateDistrictCommandValidator : AbstractValidator<CreateDistrictCommand>
{
    public CreateDistrictCommandValidator()
    {
        RuleFor(x => x.DistrictRequestDto.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(255);
    }
}