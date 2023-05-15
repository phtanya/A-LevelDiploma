using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Infrastructure;

namespace Catalog.Host.Repositories.Interfaces;

public interface IPetsFoodRepository
{
    Task<PaginatedItems<PetsFood>> GetByPageAsync(Specification<PetsFood> filter, int pageIndex, int pageSize);
    Task<int?> Add(string name, string description, decimal price, int availableStock, int petsFoodBrandId, int petsFoodTypeId, string pictureFileName);
    Task<int?> Update(int id, string name, string description, decimal price, int availableStock, int petsFoodBrandId, int petsFoodTypeId, string pictureFileName);
    Task<int?> Remove(int id);
    Task<PetsFood?> GetById(int id);
}