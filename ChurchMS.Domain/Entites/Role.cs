using ChurchMS.Domain.Common;

namespace ChurchMS.Domain.Entites;

public class Role : BaseEntity<int>
{
    public string Name { get; set; }
    public bool IsHidden { get; set; } = false;

    public virtual ICollection<RolePermissions> RolePermissions { get; set; }
    public virtual ICollection<Account> Accounts { get; set; }
}