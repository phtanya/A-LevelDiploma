using System.ComponentModel.DataAnnotations;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Models.Requests;

public class CreatePetsFoodRequest
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = null!;

    [StringLength(1000)]
    public string Description { get; set; } = null!;

    [Required]
    public decimal? Price { get; set; }

    public string PictureFileName { get; set; } = null!;

    [Required]
    public int? PetsFoodTypeId { get; set; }

    [Required]
    public int? PetsFoodBrandId { get; set; }

    public int AvailableStock { get; set; }
}