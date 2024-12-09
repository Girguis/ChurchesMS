using ChurchMS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChurchMS.Domain.Entites;

public class RolePermissions : BaseEntity<int>
{
    public int Permission { get; set; }

    [ForeignKey(nameof(Role))]
    public int RoleId { get; set; }

    public virtual Role Role { get; set; }
}