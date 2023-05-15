using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface IPetsFoodService
{
    Task<int?> AddAsync(string name, string description, decimal price, int availableStock, int petsFoodBrandId, int petsFoodTypeId, string pictureFileName);
    Task<int?> UpdateAsync(int id, string name, string description, decimal price, int availableStock, int petsFoodBrandId, int petsFoodTypeId, string pictureFileName);
    Task<int?> RemoveAsync(int id);
    Task<PaginatedItemsResponse<PetsFoodDto>?> GetPetsFoodsAsync(PetsFoodFilter filter, int pageSize, int pageIndex);
    Task<PetsFoodDto?> GetById(int id);
}