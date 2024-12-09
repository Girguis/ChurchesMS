using FluentValidation;

namespace ChurchMS.Application.Features.StreetFeature.Commands.CreateStreet;

public class CreateStreetCommandValidator : AbstractValidator<CreateStreetCommand>
{
    public CreateStreetCommandValidator()
    {
        RuleFor(x => x.StreetRequestDto.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(255);

        RuleFor(x => x.StreetRequestDto.DistinctiveSign)
            .NotNull()
            .NotEmpty()
            .MaximumLength(255);

        RuleFor(x => x.StreetRequestDto.DistrictId)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);
    }
}