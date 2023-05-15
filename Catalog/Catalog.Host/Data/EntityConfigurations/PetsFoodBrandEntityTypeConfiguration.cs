using Catalog.Host.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Host.Data.EntityConfigurations;

public class PetsFoodBrandEntityTypeConfiguration
    : IEntityTypeConfiguration<PetsFoodBrand>
{
    public void Configure(EntityTypeBuilder<PetsFoodBrand> builder)
    {
        builder.ToTable("PetsFoodBrand");

        builder.HasKey(pf => pf.Id);

        builder.Property(pf => pf.Id)
            .UseHiLo("pets_food_hilo")
            .IsRequired();

        builder.Property(pfb => pfb.Brand)
            .IsRequired()
            .HasMaxLength(100);
    }
}