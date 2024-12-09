using FluentValidation;

namespace ChurchMS.Application.Features.StreetFeature.Commands.UpdateStreet;

public class UpdateStreetCommandValidator : AbstractValidator<UpdateStreetCommand>
{
    public UpdateStreetCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x.StreetRequestDto.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(255);

        RuleFor(x => x.StreetRequestDto.DistrictId)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);
    }
}
