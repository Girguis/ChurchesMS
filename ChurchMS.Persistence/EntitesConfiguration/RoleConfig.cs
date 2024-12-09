using ChurchMS.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChurchMS.Persistence.EntitesConfiguration;

internal class RoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(new Role()
        {
            Id = 1,
            IsHidden = true,
            Name = "SuperAdmin",
            CreatedBy = "Self",
            ModifiedBy = "Self",
        });
    }
}