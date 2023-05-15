using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories
{
    public class PetsFoodTypeRepository : IPetsFoodTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PetsFoodTypeRepository(IDbContextWrapper<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext.DbContext;
        }

        public async Task<int?> Add(string petsFoodTypeName)
        {
            var petsFoodType = await _dbContext.AddAsync(new PetsFoodType
            {
                Type = petsFoodTypeName
            });

            await _dbContext.SaveChangesAsync();

            return petsFoodType.Entity.Id;
        }

        public async Task<int?> Update(int id, string name)
        {
            var petsFoodType = new PetsFoodType
            {
                Id = id,
                Type = name
            };

            _dbContext.Update(petsFoodType);
            await _dbContext.SaveChangesAsync();

            return petsFoodType.Id;
        }

        public Task<int?> Remove(int id)
        {
            return RepositoryHelper.Remove<PetsFoodType>(_dbContext, id);
        }

        public Task<List<PetsFoodType>> GetAllAsync()
        {
            return _dbContext.PetsFoodTypes.ToListAsync();
        }
    }
}
