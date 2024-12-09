using System.ComponentModel.DataAnnotations;

namespace ChurchMS.Application.Features.CityFeature.Dtos;

public class CityResponseDto
{
    public int Id { get; set; }

    [Display(Name = "Name")]
    public string Name { get; set; }
}