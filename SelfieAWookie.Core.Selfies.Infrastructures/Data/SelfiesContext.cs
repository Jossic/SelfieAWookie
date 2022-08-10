using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Framework;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Data.TypeConfiguration;

namespace SelfieAWookie.Core.Selfies.Infrastructures.Data;

public class SelfiesContext : DbContext, IUnitOfWork
{
    public DbSet<Selfie>? Selfies { get; private set; }
    public DbSet<Wookie>? Wookies { get; private set; }
    public SelfiesContext(DbContextOptions options) : base(options) { }
    public SelfiesContext() { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new SelfieEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new WookieEntityTypeConfiguration());
    }

}