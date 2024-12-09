using ChurchMS.Domain.Common;

namespace ChurchMS.Domain.Entites;

public class Account : BaseEntity<string>
{
    public string UserName { get; set; }
    public string Password { get; set; }

    public virtual ICollection<AccountRoles> AccountRoles { get; set; }
}