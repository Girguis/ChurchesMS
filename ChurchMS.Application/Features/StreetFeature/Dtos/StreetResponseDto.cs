using ChurchMS.Application.Features.DistrictFeature.Dtos;

namespace ChurchMS.Application.Features.StreetFeature.Dtos;

public class StreetResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string DistinctiveSign { get; set; }
    public DistrictResponseDto District { get; set; }
}