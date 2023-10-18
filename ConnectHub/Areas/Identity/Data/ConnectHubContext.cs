using ConnectHub.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectHub.Areas.Identity.Data;

public class ConnectHubContext : IdentityDbContext<ConnectHubUser>
{
    public ConnectHubContext(DbContextOptions<ConnectHubContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ConnectHubUserEntityConfiguration());
    }
}

internal class ConnectHubUserEntityConfiguration : IEntityTypeConfiguration<ConnectHubUser>
{
    public void Configure(EntityTypeBuilder<ConnectHubUser> builder)
    {
        builder.Property(u => u.Firstname).HasMaxLength(255);
        builder.Property(u => u.Lastname).HasMaxLength(255);
    }
}