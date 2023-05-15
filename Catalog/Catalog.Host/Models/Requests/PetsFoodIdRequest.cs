using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests
{
    public class PetsFoodIdRequest
    {
        [Required]
        public int? Id { get; set; }
    }
}
