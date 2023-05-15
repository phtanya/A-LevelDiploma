using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class PetsFoodBrandService : BaseDataService<ApplicationDbContext>, IPetsFoodBrandService
    {
        private readonly IPetsFoodBrandRepository _petsFoodBrandRepository;
        private readonly IMapper _mapper;

        public PetsFoodBrandService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            IPetsFoodBrandRepository petsFoodBrandRepository,
            IMapper mapper)
        : base(dbContextWrapper, logger)
        {
            _petsFoodBrandRepository = petsFoodBrandRepository;
            _mapper = mapper;
        }

        public Task<int?> AddAsync(string brand)
        {
            return ExecuteSafeAsync(() => _petsFoodBrandRepository.Add(brand));
        }

        public Task<int?> UpdateAsync(int id, string brand)
        {
            return ExecuteSafeAsync(() => _petsFoodBrandRepository.Update(id, brand));
        }

        public Task<int?> RemoveAsync(int id)
        {
            return ExecuteSafeAsync(() => _petsFoodBrandRepository.Remove(id));
        }

        public Task<List<PetsFoodBrandDto>> GetAllAsync()
        {
            return ExecuteSafeAsync(async () =>
            {
                var brands = await _petsFoodBrandRepository.GetAllAsync();
                return brands.Select(_ => _mapper.Map<PetsFoodBrandDto>(_)).ToList();
            });
        }
    }
}
