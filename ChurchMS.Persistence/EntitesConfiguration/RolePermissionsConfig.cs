using ChurchMS.Domain.Entites;
using ChurchMS.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChurchMS.Persistence.EntitesConfiguration;

internal class RolePermissionsConfig : IEntityTypeConfiguration<RolePermissions>
{
    public void Configure(EntityTypeBuilder<RolePermissions> builder)
    {
        builder.HasData(new RolePermissions()
        {
            Id = 1,
            RoleId = 1,
            Permission = (int)PermissionsEnum.FullAccess,
            CreatedBy = "Self",
            ModifiedBy = "Self",
        });
    }
}