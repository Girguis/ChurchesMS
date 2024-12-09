using ChurchMS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChurchMS.Domain.Entites;

public class AccountRoles : BaseEntity<int>
{
    [ForeignKey(nameof(Account))]
    public string AccountId { get; set; }

    [ForeignKey(nameof(Role))]
    public int RoleId { get; set; }

    public virtual Role Role { get; set; }
    public virtual Account Account { get; set; }
}