using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfieAWookie.Core.Selfies.Domain;

namespace SelfieAWookie.Core.Selfies.Infrastructures.Data.TypeConfiguration;

public class SelfieEntityTypeConfiguration : IEntityTypeConfiguration<Selfie>
{
    public void Configure(EntityTypeBuilder<Selfie> builder)
    {
        builder.ToTable("Selfie");

        builder.HasKey(selfie => selfie.Id);
        builder.HasOne(item => item.Wookie)
            .WithMany(item => item.Selfies);
    }
}