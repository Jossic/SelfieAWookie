using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SelfieAWookie.Core.Selfies.Infrastructures.Data;

public class SelfiesContextFactory : IDesignTimeDbContextFactory<SelfiesContext>
{
    public SelfiesContext CreateDbContext(string[] args)
    {
        ConfigurationBuilder configurationBuilder = new();

        configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "Settings", "appSettings.json"));

        IConfigurationRoot configurationRoot = configurationBuilder.Build();

        DbContextOptionsBuilder builder = new();
        builder.UseSqlServer(configurationRoot.GetConnectionString("SelfiesDb"), b => b.MigrationsAssembly("SelfieAWookie.Core.Selfies.Infrastructures"));

        SelfiesContext context = new SelfiesContext(builder.Options);

        return context;
    }
}
