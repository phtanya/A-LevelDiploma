#pragma warning disable CS8618

using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Data.Entities
{
    public class PetsFoodBrand : IBaseEntity
    {
        public int Id { get; set; }

        public string Brand { get; set; }
    }
}
