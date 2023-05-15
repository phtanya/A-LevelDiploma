using System.Threading;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Infrastructure;

namespace Catalog.UnitTests.Services
{
    public class PetsFoodServiceTest
    {
        private readonly IPetsFoodService _petsFoodService;

        private readonly Mock<IPetsFoodRepository> _petsFoodRepository;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<PetsFoodService>> _logger;
        private readonly Mock<IMapper> _mapper;

        private readonly PetsFood _testPetsFood = new PetsFood()
        {
            Name = "NewFood",
            Description = "Description of Product",
            Price = 100,
            PictureFileName = "22.png",
            PetsFoodBrandId = 3,
            PetsFoodTypeId = 1,
            AvailableStock = 100
        };

        public PetsFoodServiceTest()
        {
            _petsFoodRepository = new Mock<IPetsFoodRepository>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _logger = new Mock<ILogger<PetsFoodService>>();
            _mapper = new Mock<IMapper>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(It.IsAny<CancellationToken>())).ReturnsAsync(dbContextTransaction.Object);

            _petsFoodService = new PetsFoodService(_dbContextWrapper.Object, _logger.Object, _petsFoodRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task AddAsync_Success()
        {
            // arrange
            var testResult = 1;

            _petsFoodRepository.Setup(s => s.Add(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _petsFoodService.AddAsync(
                _testPetsFood.Name,
                _testPetsFood.Description,
                _testPetsFood.Price,
                _testPetsFood.AvailableStock,
                _testPetsFood.PetsFoodBrandId,
                _testPetsFood.PetsFoodTypeId,
                _testPetsFood.PictureFileName);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task AddAsync_Failed()
        {
            // arrange
            int? testResult = null;

            _petsFoodRepository.Setup(s => s.Add(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(testResult);

            // act
            var result = await _petsFoodService.AddAsync(
                _testPetsFood.Name,
                _testPetsFood.Description,
                _testPetsFood.Price,
                _testPetsFood.AvailableStock,
                _testPetsFood.PetsFoodBrandId,
                _testPetsFood.PetsFoodTypeId,
                _testPetsFood.PictureFileName);

            // assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task GetLaptopsAsync_UseValidParameters_ReturnCorrespondigData()
        {
            // Arrange
            var pageIndex = 1;
            var pageSize = 2;
            var filter = new PetsFoodFilter();
            var petfood1 = new PetsFood()
            {
                Name = "Name1"
            };
            var petfood2 = new PetsFood()
            {
                Name = "Name2"
            };
            _petsFoodRepository
               .Setup(_ => _.GetByPageAsync(It.IsAny<Specification<PetsFood>>(), It.IsAny<int>(), It.IsAny<int>()))
               .ReturnsAsync(new PaginatedItems<PetsFood>()
               {
                   TotalCount = 2,
                   Data = new List<PetsFood>() { petfood1, petfood2 }
               });
            _mapper
                .Setup(s => s.Map<PetsFoodDto>(It.Is<PetsFood>(_ => _ == petfood1)))
                .Returns(new PetsFoodDto { Name = "Name1" });
            _mapper
                .Setup(s => s.Map<PetsFoodDto>(It.Is<PetsFood>(_ => _ == petfood2)))
                .Returns(new PetsFoodDto { Name = "Name2" });

            // Act
            var result = await _petsFoodService.GetPetsFoodsAsync(filter, pageSize, pageIndex);

            // Assert
            result.Should().NotBeNull();
            result?.PageIndex.Should().Be(pageIndex);
            result?.PageSize.Should().Be(pageSize);
            result?.Count.Should().Be(2);
            result?.Data.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task GetPetsFoodsAsync_UseZeroPageIndexPageSize_ReturnEmptyData()
        {
            // Arrange
            _petsFoodRepository
                .Setup(_ => _.GetByPageAsync(It.IsAny<Specification<PetsFood>>(), It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(new PaginatedItems<PetsFood>()
                {
                    Data = new List<PetsFood>()
                });

            // Act
            var result = await _petsFoodService.GetPetsFoodsAsync(new (), 0, 0);

            // Assert
            result.Should().NotBeNull();
            result?.PageIndex.Should().Be(0);
            result?.PageSize.Should().Be(0);
            result?.Data.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task GetPetsFoodsAsync_InvalidPageIndex_ReturnNull()
        {
            // Arrange
            const int invalidIndex = 1;
            _petsFoodRepository
                .Setup(_ => _.GetByPageAsync(It.IsAny<Specification<PetsFood>>(), It.Is<int>(i => i == invalidIndex), It.IsAny<int>()))
                .ReturnsAsync((PaginatedItems<PetsFood>)null!);

            // Act
            var result = await _petsFoodService.GetPetsFoodsAsync(new (), 10, invalidIndex);

            // Assert
            result.Should().BeNull();
        }
    }
}
