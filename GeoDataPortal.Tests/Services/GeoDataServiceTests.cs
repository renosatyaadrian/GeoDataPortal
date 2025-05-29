using Moq;
using GeoDataPortal.Application.Service;
using GeoDataPortal.Application.DTOs.GeoData;
using GeoDataPortal.Domain.Entities;
using GeoDataPortal.Domain.Interfaces; 

namespace GeoDataPortal.Tests.Application.Services
{
    public class GeoDataServiceTests
    {
        private readonly Mock<IGeoDataRepository> _mockGeoDataRepository;
        private readonly GeoDataService _geoDataService;

        public GeoDataServiceTests()
        {
            _mockGeoDataRepository = new Mock<IGeoDataRepository>();
            _geoDataService = new GeoDataService(_mockGeoDataRepository.Object);
        }

        [Fact]
        public async Task AddGeodataAsync_CalledRepositoryOnce()
        {
            // Arrange
            var inputDto = new AddUpdateGeoDataDto
            {
                Name = "Test Location",
                GeoJson = "{ \"type\": \"Point\", \"coordinates\": [10, 20] }"
            };

            _mockGeoDataRepository.Setup(r => r.AddAsync(It.IsAny<GeoData>()))
                .Returns(Task.CompletedTask);

            // Act
            await _geoDataService.AddGeodataAsync(inputDto);

            // Assert
            _mockGeoDataRepository.Verify(r => r.AddAsync(It.Is<GeoData>(
                g => g.Name == inputDto.Name &&
                     g.GeoJson == inputDto.GeoJson)), Times.Once());
        }

        [Fact]
        public async Task DeleteGeoDataAsync_CalledRepositoryOnce()
        {
            // Arrange
            var geoDataId = Guid.NewGuid();

            _mockGeoDataRepository.Setup(r => r.DeleteAsync(geoDataId))
                .Returns(Task.CompletedTask);

            // Act
            await _geoDataService.DeleteGeoDataAsync(geoDataId);

            // Assert
            _mockGeoDataRepository.Verify(r => r.DeleteAsync(geoDataId), Times.Once());
        }

        [Fact]
        public async Task GetAllGeoDataAsync_Found()
        {
            // Arrange
            var geoDataList = new List<GeoData>
            {
                new GeoData { Id = Guid.NewGuid(), Name = "Location A", GeoJson = "{ \"type\": \"Point\", \"coordinates\": [1, 2] }" },
                new GeoData { Id = Guid.NewGuid(), Name = "Location B", GeoJson = "{ \"type\": \"Point\", \"coordinates\": [3, 4] }" }
            };

            _mockGeoDataRepository.Setup(r => r.GetAllAsync())
                .ReturnsAsync(geoDataList);

            // Act
            var result = await _geoDataService.GetAllGeoDataAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(geoDataList.Count, result.Count());

            foreach (var original in geoDataList)
            {
                var mapped = result.FirstOrDefault(dto => dto.Id == original.Id);
                Assert.NotNull(mapped);
                Assert.Equal(original.Name, mapped.Name);
                Assert.Equal(original.GeoJson, mapped.GeoJson);
            }

            _mockGeoDataRepository.Verify(r => r.GetAllAsync(), Times.Once());
        }

        [Fact]
        public async Task GetGeoDataByIdAsync_Found()
        {
            // Arrange
            var geoDataId = Guid.NewGuid();
            var geoDataEntity = new GeoData
            {
                Id = geoDataId,
                Name = "Specific Location",
                GeoJson = "{ \"type\": \"Polygon\", \"coordinates\": [[[0,0],[0,1],[1,1],[1,0],[0,0]]] }"
            };

            _mockGeoDataRepository.Setup(r => r.GetByIdAsync(geoDataId))
                .ReturnsAsync(geoDataEntity);

            // Act
            var result = await _geoDataService.GetGeoDataByIdAsync(geoDataId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(geoDataEntity.Id, result.Id);
            Assert.Equal(geoDataEntity.GeoJson, result.GeoJson);
            Assert.Equal(geoDataEntity.Name, result.Name);

            _mockGeoDataRepository.Verify(r => r.GetByIdAsync(geoDataId), Times.Once());
        }

        [Fact]
        public async Task GetGeoDataByIdAsync_NotFound()
        {
            // Arrange
            var geoDataId = Guid.NewGuid();

            _mockGeoDataRepository.Setup(r => r.GetByIdAsync(geoDataId))
                .ReturnsAsync((GeoData?)null);

            // Act
            var result = await _geoDataService.GetGeoDataByIdAsync(geoDataId);

            // Assert
            Assert.Null(result);

            _mockGeoDataRepository.Verify(r => r.GetByIdAsync(geoDataId), Times.Once());
        }
    }
}