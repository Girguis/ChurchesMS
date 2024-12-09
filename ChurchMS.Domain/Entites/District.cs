using ChurchMS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChurchMS.Domain.Entites;

public class District : BaseEntity<int>
{
    public string Name { get; set; }

    [ForeignKey(nameof(CityId))]
    public int CityId { get; set; }

    public virtual City City { get; set; }
    public virtual ICollection<Street> Street { get; set; }
}