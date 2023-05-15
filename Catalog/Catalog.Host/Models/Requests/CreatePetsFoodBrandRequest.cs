using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests
{
    public class CreatePetsFoodBrandRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Brand { get; set; } = null!;
    }
}
