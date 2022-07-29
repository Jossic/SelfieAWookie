using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Domain;

namespace SelfieAWookie.Core.Selfies.Infrastructures.Data;

public class SelfiesContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Selfie> Selfies { get; }
    public DbSet<Wookie> Wookies { get; }
}