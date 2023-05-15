#pragma warning disable CS8618
namespace Catalog.Host.Models.Dtos;

public class PetsFoodDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string PictureUrl { get; set; }

    public PetsFoodTypeDto PetsFoodType { get; set; }

    public PetsFoodBrandDto PetsFoodBrand { get; set; }

    public int AvailableStock { get; set; }
}
