using ChurchMS.Application.Features.Shared.Validators;
using FluentValidation;

namespace ChurchMS.Application.Features.DistrictFeature.Queries.GetFilteredDistricts;

public class GetFilteredDistrictsQueryValidator : AbstractValidator<GetFilteredDistrictsQuery>
{
    public GetFilteredDistrictsQueryValidator()
    {
        RuleFor(x => x.QueryDto)
            .SetValidator(new QueryDtoValidator());
    }
}