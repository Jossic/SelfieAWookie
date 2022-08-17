using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Infrastructures.Data;

public class SelfiesContextFactory : IDesignTimeDbContextFactory<SelfiesContext>
{
    public SelfiesContext CreateDbContext(string[] args)
    {
        ConfigurationBuilder configurationBuilder = new();

        configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "Settings" ,"appSettings.json"));

        var configurationRoot = configurationBuilder.Build();

        

        DbContextOptionsBuilder builder = new();

        builder.UseSqlServer(configurationRoot.GetConnectionString("SelfiesDb"));

        SelfiesContext context = new SelfiesContext(builder.Options);

        return context;
            }
}
