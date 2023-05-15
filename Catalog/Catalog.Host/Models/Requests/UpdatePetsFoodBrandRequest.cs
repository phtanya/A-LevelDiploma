using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests
{
    public class UpdatePetsFoodBrandRequest
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Brand { get; set; } = null!;
    }
}
