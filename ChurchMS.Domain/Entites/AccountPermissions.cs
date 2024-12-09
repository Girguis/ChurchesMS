using ChurchMS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChurchMS.Domain.Entites;

public class AccountPermissions : BaseEntity<int>
{
    [ForeignKey(nameof(Account))]
    public int AccountId { get; set; }
    public int Permission { get; set; }

    public virtual Account Account { get; set; }
}