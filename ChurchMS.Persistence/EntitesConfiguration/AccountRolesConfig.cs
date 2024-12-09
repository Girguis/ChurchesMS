using ChurchMS.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChurchMS.Persistence.EntitesConfiguration;

internal class AccountRolesConfig : IEntityTypeConfiguration<AccountRoles>
{
    public void Configure(EntityTypeBuilder<AccountRoles> builder)
    {
        builder.HasData(new AccountRoles()
        {
            Id = 1,
            CreatedBy = "Self",
            ModifiedBy = "Self",
            AccountId = "0283150F-5BB1-4DF2-87C5-AC3553384A1C",
            RoleId = 1,
        });
    }
}