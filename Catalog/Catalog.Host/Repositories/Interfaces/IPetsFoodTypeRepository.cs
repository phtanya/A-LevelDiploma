using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface IPetsFoodTypeRepository
    {
        Task<int?> Add(string petsFoodType);
        Task<int?> Update(int id, string type);
        Task<int?> Remove(int id);
        Task<List<PetsFoodType>> GetAllAsync();
    }
}
