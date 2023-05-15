#pragma warning disable CS8618

using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Data.Entities
{
    public class PetsFoodType : IBaseEntity
    {
        public int Id { get; set; }

        public string Type { get; set; }
    }
}
