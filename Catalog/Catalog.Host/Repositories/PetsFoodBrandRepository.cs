using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories
{
    public class PetsFoodBrandRepository : IPetsFoodBrandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PetsFoodBrandRepository(IDbContextWrapper<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext.DbContext;
        }

        public async Task<int?> Add(string brandName)
        {
            var brand = await _dbContext.AddAsync(new PetsFoodBrand
            {
                Brand = brandName
            });

            await _dbContext.SaveChangesAsync();

            return brand.Entity.Id;
        }

        public async Task<int?> Update(int id, string brandName)
        {
            var brand = new PetsFoodBrand
            {
                Id = id,
                Brand = brandName
            };

            _dbContext.Update(brand);
            await _dbContext.SaveChangesAsync();

            return brand.Id;
        }

        public Task<int?> Remove(int id)
        {
            return RepositoryHelper.Remove<PetsFoodBrand>(_dbContext, id);
        }

        public Task<List<PetsFoodBrand>> GetAllAsync()
        {
            return _dbContext.PetsFoodBrands.ToListAsync();
        }
    }
}
