using ChurchMS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChurchMS.Domain.Entites;

public class Street : BaseEntity<int>
{
    public string Name { get; set; }
    public string DistinctiveSign { get; set; }

    [ForeignKey(nameof(DistrictId))]
    public int DistrictId { get; set; }

    public virtual District District { get; set; }
}