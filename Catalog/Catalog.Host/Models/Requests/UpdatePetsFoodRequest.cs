using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests
{
    public class UpdatePetsFoodRequest : CreatePetsFoodRequest
    {
        [Required]
        public int? Id { get; set; }
    }
}
