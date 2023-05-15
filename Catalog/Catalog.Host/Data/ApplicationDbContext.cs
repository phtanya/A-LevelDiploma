#pragma warning disable CS8618
using Catalog.Host.Data.Entities;
using Catalog.Host.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<PetsFood> PetsFoods { get; set; } = null!;
    public DbSet<PetsFoodBrand> PetsFoodBrands { get; set; } = null!;
    public DbSet<PetsFoodType> PetsFoodTypes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new PetsFoodBrandEntityTypeConfiguration());
        builder.ApplyConfiguration(new PetsFoodTypeEntityTypeConfiguration());
        builder.ApplyConfiguration(new PetsFoodEntityTypeConfiguration());
    }
}
