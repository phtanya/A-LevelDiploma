using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Host.Data.EntityConfigurations;

public class PetsFoodTypeEntityTypeConfiguration
    : IEntityTypeConfiguration<PetsFoodType>
{
    public void Configure(EntityTypeBuilder<PetsFoodType> builder)
    {
        builder.ToTable("PetsFoodType");

        builder.HasKey(pf => pf.Id);

        builder.Property(pf => pf.Id)
            .UseHiLo("pets_food_type_hilo")
            .IsRequired();

        builder.Property(pfb => pfb.Type)
            .IsRequired()
            .HasMaxLength(100);
    }
}