using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class PetsFoodRepository : IPetsFoodRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<PetsFoodRepository> _logger;

    public PetsFoodRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<PetsFoodRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<PaginatedItems<PetsFood>> GetByPageAsync(Specification<PetsFood> filter, int pageIndex, int pageSize)
    {
        IQueryable<PetsFood> query = _dbContext.PetsFoods.Where(filter);

        var totalItems = await query.LongCountAsync();

        var itemsOnPage = await query.OrderBy(pf => pf.Name)
            .Include(i => i.PetsFoodBrand)
            .Include(i => i.PetsFoodType)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<PetsFood>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<int?> Add(string name, string description, decimal price, int availableStock, int petsFoodBrandId, int petsFoodTypeId, string pictureFileName)
    {
        var item = await _dbContext.AddAsync(new PetsFood
        {
            PetsFoodBrandId = petsFoodBrandId,
            PetsFoodTypeId = petsFoodTypeId,
            Description = description,
            Name = name,
            PictureFileName = pictureFileName,
            Price = price
        });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<int?> Update(int id, string name, string description, decimal price, int availableStock, int petsFoodBrandId, int petsFoodTypeId, string pictureFileName)
    {
        var laptop = new PetsFood
        {
            Id = id,
            Name = name,
            Description = description,
            Price = price,
            AvailableStock = availableStock,
            PetsFoodBrandId = petsFoodBrandId,
            PetsFoodTypeId = petsFoodTypeId,
            PictureFileName = pictureFileName
        };

        _dbContext.Update(laptop);
        await _dbContext.SaveChangesAsync();

        return laptop.Id;
    }

    public async Task<PetsFood?> GetById(int id)
    {
        return await _dbContext.PetsFoods
            .Include(i => i.PetsFoodBrand)
            .Include(i => i.PetsFoodType)
            .FirstOrDefaultAsync(_ => _.Id == id);
    }

    public Task<int?> Remove(int id)
    {
        return RepositoryHelper.Remove<PetsFood>(_dbContext, id);
    }
}