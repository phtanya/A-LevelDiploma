using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class PetsFoodTypeService : BaseDataService<ApplicationDbContext>, IPetsFoodTypeService
    {
        private readonly IPetsFoodTypeRepository _petsFoodTypeRepository;
        private readonly IMapper _mapper;
        public PetsFoodTypeService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            IPetsFoodTypeRepository petsFoodTypeRepository,
            IMapper mapper)
        : base(dbContextWrapper, logger)
        {
            _petsFoodTypeRepository = petsFoodTypeRepository;
            _mapper = mapper;
        }

        public Task<int?> AddAsync(string petsFoodType)
        {
            return ExecuteSafeAsync(() => _petsFoodTypeRepository.Add(petsFoodType));
        }

        public Task<int?> UpdateAsync(int id, string type)
        {
            return ExecuteSafeAsync(() => _petsFoodTypeRepository.Update(id, type));
        }

        public Task<int?> RemoveAsync(int id)
        {
            return ExecuteSafeAsync(() => _petsFoodTypeRepository.Remove(id));
        }

        public Task<List<PetsFoodTypeDto>> GetAllAsync()
        {
            return ExecuteSafeAsync(async () =>
            {
                var petsFoodTypes = await _petsFoodTypeRepository.GetAllAsync();
                return petsFoodTypes.Select(_ => _mapper.Map<PetsFoodTypeDto>(_)).ToList();
            });
        }
    }
}
