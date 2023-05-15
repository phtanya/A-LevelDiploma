#pragma warning disable CS8618

namespace Catalog.Host.Data.Entities;

public class PetsFood : IBaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string PictureFileName { get; set; }

    public int PetsFoodTypeId { get; set; }

    public PetsFoodType PetsFoodType { get; set; }

    public int PetsFoodBrandId { get; set; }

    public PetsFoodBrand PetsFoodBrand { get; set; }

    public int AvailableStock { get; set; }
}