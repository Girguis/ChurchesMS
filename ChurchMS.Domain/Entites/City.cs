using ChurchMS.Domain.Common;

namespace ChurchMS.Domain.Entites;

public class City : BaseEntity<int>
{
    public string Name { get; set; }

    public virtual ICollection<District> District { get; set; }
}