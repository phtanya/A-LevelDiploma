using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface IPetsFoodBrandRepository
    {
        Task<int?> Add(string petsFoodBrand);
        Task<int?> Update(int id, string name);
        Task<int?> Remove(int id);
        Task<List<PetsFoodBrand>> GetAllAsync();
    }
}
