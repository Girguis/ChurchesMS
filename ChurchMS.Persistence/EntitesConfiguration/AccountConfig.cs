using ChurchMS.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChurchMS.Persistence.EntitesConfiguration;

internal class AccountConfig : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasData(new Account()
        {
            Id = "0283150F-5BB1-4DF2-87C5-AC3553384A1C",
            CreatedBy = "Self",
            ModifiedBy = "Self",
            UserName = "SuperAdmin",
            Password = "PlainPassword",
        });
    }
}