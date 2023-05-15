using Catalog.Host.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Host.Data.EntityConfigurations;

public class PetsFoodEntityTypeConfiguration
    : IEntityTypeConfiguration<PetsFood>
{
    public void Configure(EntityTypeBuilder<PetsFood> builder)
    {
        builder.ToTable("PetsFood");

        builder.Property(pf => pf.Id)
            .UseHiLo("pets_food_hilo")
            .IsRequired();

        builder.Property(pf => pf.Name)
            .IsRequired(true)
            .HasMaxLength(50);

        builder.Property(pf => pf.Price)
            .IsRequired(true);

        builder.Property(pf => pf.Description)
               .IsRequired(false);

        builder.Property(pf => pf.PictureFileName)
            .IsRequired(false);

        builder.HasOne(pf => pf.PetsFoodBrand)
            .WithMany()
            .HasForeignKey(pf => pf.PetsFoodBrandId);

        builder.HasOne(pf => pf.PetsFoodType)
            .WithMany()
            .HasForeignKey(pf => pf.PetsFoodTypeId);

        builder.Property(pf => pf.AvailableStock)
            .IsRequired(true);
    }
}