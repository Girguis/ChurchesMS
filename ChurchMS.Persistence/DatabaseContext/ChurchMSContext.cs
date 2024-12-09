using ChurchMS.Domain.Common;
using ChurchMS.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace ChurchMS.Persistence.DatabaseContext;

public class ChurchMSContext : DbContext
{
    public ChurchMSContext(DbContextOptions<ChurchMSContext> options) : base(options)
    {

    }

    public Account Accounts { get; set; }
    public AccountPermissions AccountPermissions { get; set; }
    public AccountRoles AccountRoles { get; set; }
    public Role Roles { get; set; }
    public RolePermissions RolePermissions { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Street> Streets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChurchMSContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = base.ChangeTracker
                            .Entries()
                            .Where(x => x.Entity.GetType().BaseType != null &&
                                        x.Entity.GetType().BaseType!.IsGenericType &&
                                        x.Entity.GetType().BaseType!.GetGenericTypeDefinition() == typeof(BaseEntity<>) &&
                                        (x.State == EntityState.Added ||
                                            x.State == EntityState.Modified));
        foreach (var entry in entries)
        {
            var entity = entry.Entity as dynamic;
            if (entry.State == EntityState.Added)
            {
                entity.CreatedAt = DateTime.UtcNow;
                entity.CreatedBy = "Demo";
            }

            entity.ModifiedAt = DateTime.UtcNow;
            entity.ModifiedBy = "Demo";
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}