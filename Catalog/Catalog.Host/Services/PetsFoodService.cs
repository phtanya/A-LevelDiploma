using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Services;

public class PetsFoodService : BaseDataService<ApplicationDbContext>, IPetsFoodService
{
    private readonly IPetsFoodRepository _petsFoodRepository;
    private readonly IMapper _mapper;

    public PetsFoodService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IPetsFoodRepository petsFoodRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _petsFoodRepository = petsFoodRepository;
        _mapper = mapper;
    }

    public Task<int?> AddAsync(string name, string description, decimal price, int availableStock, int petsFoodBrandId, int petsFoodTypeId, string pictureFileName)
    {
        return ExecuteSafeAsync(() => _petsFoodRepository.Add(name, description, price, availableStock, petsFoodBrandId, petsFoodTypeId, pictureFileName));
    }

    public async Task<PetsFoodDto?> GetById(int id)
    {
        var petsFood = await _petsFoodRepository.GetById(id);
        if (petsFood == null)
        {
            return null;
        }

        return _mapper.Map<PetsFoodDto>(petsFood);
    }

    public async Task<PaginatedItemsResponse<PetsFoodDto>?> GetPetsFoodsAsync(PetsFoodFilter filter, int pageSize, int pageIndex)
    {
        var spec = Specification.New<PetsFood>(_ => true);
        if (filter.PetsFoodBrandId.HasValue)
        {
            spec &= _ => _.PetsFoodBrandId == filter.PetsFoodBrandId;
        }

        if (filter.PetsFoodTypeId.HasValue)
        {
            spec &= _ => _.PetsFoodTypeId == filter.PetsFoodTypeId;
        }

        var result = await _petsFoodRepository.GetByPageAsync(spec, pageSize, pageIndex);
        if (result == null)
        {
            return null;
        }

        return new PaginatedItemsResponse<PetsFoodDto>()
        {
            Count = result.TotalCount,
            Data = result.Data.Select(s => _mapper.Map<PetsFoodDto>(s)).ToList(),
            PageIndex = pageIndex,
            PageSize = pageSize
        };
    }

    public Task<int?> RemoveAsync(int id)
    {
        return ExecuteSafeAsync(() => _petsFoodRepository.Remove(id));
    }

    public Task<int?> UpdateAsync(int id, string name, string description, decimal price, int availableStock, int petsFoodBrandId, int petsFoodTypeId, string pictureFileName)
    {
        return ExecuteSafeAsync(() => _petsFoodRepository.Update(id, name, description, price, availableStock, petsFoodBrandId, petsFoodTypeId, pictureFileName));
    }
}