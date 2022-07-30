using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Data.TypeConfiguration;

namespace SelfieAWookie.Core.Selfies.Infrastructures.Data;

public class SelfiesContext : DbContext
{

    public SelfiesContext([NotNull] DbContextOptions options): base(options){}
    public SelfiesContext(): base(){}
    
        
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new SelfieEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new WookieEntityTypeConfiguration());
    }

    public DbSet<Selfie> Selfies { get; }
    public DbSet<Wookie> Wookies { get; }
}