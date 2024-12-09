using ChurchMS.Application.Features.CityFeature.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ChurchMS.Application.Features.DistrictFeature.Dtos;

public class DistrictResponseDto
{
    public int Id { get; set; }

    [Display(Name = "Name")]
    public string Name { get; set; }

    public CityResponseDto City { get; set; }
}