using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests
{
    public class CreatePetsFoodTypeRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Type { get; set; } = null!;
    }
}
