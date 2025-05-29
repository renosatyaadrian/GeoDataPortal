using Moq;
using GeoDataPortal.Application.Service;
using GeoDataPortal.Application.DTOs.Timeseries;
using GeoDataPortal.Domain.Entities;
using GeoDataPortal.Domain.Interfaces;

namespace GeoDataPortal.Tests.Application.Services
{
    public class TimeseriesServiceTests
    {
        private readonly Mock<ITimeseriesRepository> _mockTimeseriesRepository;
        private readonly TimeseriesService _timeseriesService;

        public TimeseriesServiceTests()
        {
            _mockTimeseriesRepository = new Mock<ITimeseriesRepository>();
            _timeseriesService = new TimeseriesService(_mockTimeseriesRepository.Object);
        }

        [Fact]
        public async Task AddTimeseriesAsync_CalledRepositoryOnce()
        {
            // Arrange
            var geoDataId = Guid.NewGuid();
            var inputDto = new AddUpdateTimeseriesDto
            {
                GeoDataId = geoDataId,
                Timestamp = DateTime.UtcNow,
                Type = "Temperature",
                Unit = "Celsius",
                Value = 25.5
            };

            _mockTimeseriesRepository.Setup(r => r.AddAsync(It.IsAny<Timeseries>()))
                .Returns(Task.CompletedTask);

            // Act
            await _timeseriesService.AddTimeseriesAsync(inputDto);

            // Assert

            _mockTimeseriesRepository.Verify(r => r.AddAsync(It.Is<Timeseries>(
                t => t.GeoDataId == inputDto.GeoDataId &&
                     t.Timestamp == inputDto.Timestamp &&
                     t.Type == inputDto.Type &&
                     t.Unit == inputDto.Unit &&
                     t.Value == inputDto.Value)), Times.Once());
        }

        [Fact]
        public async Task DeleteTimeseriesAsync_CalledRepositoryOnce()
        {
            // Arrange
            var timeseriesId = Guid.NewGuid();

            _mockTimeseriesRepository.Setup(r => r.DeleteAsync(timeseriesId))
                .Returns(Task.CompletedTask);

            // Act
            await _timeseriesService.DeleteTimeseriesAsync(timeseriesId);

            // Assert
            _mockTimeseriesRepository.Verify(r => r.DeleteAsync(timeseriesId), Times.Once());
        }

        [Fact]
        public async Task GetTimeseriesByGeoDataIdAsync_Found()
        {
            // Arrange
            var geoDataId = Guid.NewGuid();
            var timeseriesList = new List<Timeseries>
            {
                new() { Id = Guid.NewGuid(), GeoDataId = geoDataId, Timestamp = DateTime.UtcNow.AddHours(-1), Type = "Temp", Unit = "C", Value = 20.0 },
                new() { Id = Guid.NewGuid(), GeoDataId = geoDataId, Timestamp = DateTime.UtcNow, Type = "Temp", Unit = "C", Value = 22.0 }
            };

            _mockTimeseriesRepository.Setup(r => r.GetByGeoDataIdAsync(geoDataId))
                .ReturnsAsync(timeseriesList);

            // Act
            var result = await _timeseriesService.GetTimeseriesByGeoDataIdAsync(geoDataId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(timeseriesList.Count, result.Count()); 
            
            foreach (var original in timeseriesList)
            {
                var mapped = result.FirstOrDefault(dto => dto.Id == original.Id);
                Assert.NotNull(mapped);
                Assert.Equal(original.GeoDataId, mapped.GeoDataId);
                Assert.Equal(original.Timestamp, mapped.Timestamp);
                Assert.Equal(original.Type, mapped.Type);
                Assert.Equal(original.Unit, mapped.Unit);
                Assert.Equal(original.Value, mapped.Value);
            }
            
            _mockTimeseriesRepository.Verify(r => r.GetByGeoDataIdAsync(geoDataId), Times.Once());
        }

        [Fact]
        public async Task UpdateTimeseriesAsync_CalledRepositoryOnce()
        {
            // Arrange
            var timeseriesId = Guid.NewGuid();
            var geoDataId = Guid.NewGuid();
            var inputDto = new AddUpdateTimeseriesDto
            {
                Id = timeseriesId,
                GeoDataId = geoDataId,
                Timestamp = DateTime.UtcNow,
                Type = "Humidity",
                Unit = "%",
                Value = 75.0
            };

            _mockTimeseriesRepository.Setup(r => r.UpdateAsync(It.IsAny<Timeseries>()))
                .Returns(Task.CompletedTask);

            // Act
            await _timeseriesService.UpdateTimeseriesAsync(inputDto);

            // Assert
            _mockTimeseriesRepository.Verify(r => r.UpdateAsync(It.Is<Timeseries>(
                t => t.Id == inputDto.Id &&
                     t.GeoDataId == inputDto.GeoDataId &&
                     t.Timestamp == inputDto.Timestamp &&
                     t.Type == inputDto.Type &&
                     t.Unit == inputDto.Unit &&
                     t.Value == inputDto.Value)), Times.Once());
        }
    }
}