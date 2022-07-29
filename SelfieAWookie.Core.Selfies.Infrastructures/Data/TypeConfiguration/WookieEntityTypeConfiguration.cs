using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfieAWookie.Core.Selfies.Domain;

namespace SelfieAWookie.Core.Selfies.Infrastructures.Data.TypeConfiguration;

public class WookieEntityTypeConfiguration : IEntityTypeConfiguration<Wookie>
{
    public void Configure(EntityTypeBuilder<Wookie> builder)
    {
        builder.ToTable("Wookie");
    }
}