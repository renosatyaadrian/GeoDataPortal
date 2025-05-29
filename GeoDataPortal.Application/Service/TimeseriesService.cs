using GeoDataPortal.Application.DTOs.Timeseries;
using GeoDataPortal.Application.Interface;
using GeoDataPortal.Domain.Entities;
using GeoDataPortal.Domain.Interfaces;

namespace GeoDataPortal.Application.Service
{
    public class TimeseriesService : ITimeseriesService
    {
        private readonly ITimeseriesRepository _timeseriesRepository;

        public TimeseriesService(ITimeseriesRepository timeseriesRepository)
        {
            _timeseriesRepository = timeseriesRepository;
        }

        public Task AddTimeseriesAsync(AddUpdateTimeseriesDto input)
        {
            var newTimeseries = new Timeseries
            {
                GeoDataId = input.GeoDataId,
                Timestamp = input.Timestamp,
                Type = input.Type,
                Unit = input.Unit,
                Value = input.Value
            };
            return _timeseriesRepository.AddAsync(newTimeseries);
        }

        public Task DeleteTimeseriesAsync(Guid id)
        {
            return _timeseriesRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TimeseriesDetailDto>> GetTimeseriesByGeoDataIdAsync(Guid geoDataId)
        {
            var timeseries = await _timeseriesRepository.GetByGeoDataIdAsync(geoDataId);
            return timeseries
                .Select(t => new TimeseriesDetailDto
                {
                    GeoDataId = t.GeoDataId,
                    Timestamp = t.Timestamp,
                    Value = t.Value,
                    Type = t.Type,
                    Unit = t.Unit,
                    Id = t.Id
                })
                .ToList();
        }

        public Task UpdateTimeseriesAsync(AddUpdateTimeseriesDto input)
        {
            var updatedTimeseries = new Timeseries
            {
                GeoDataId = input.GeoDataId,
                Id = input.Id!.Value,
                Timestamp = input.Timestamp,
                Type = input.Type,
                Unit = input.Unit,
                Value = input.Value
            };
            return _timeseriesRepository.UpdateAsync(updatedTimeseries);
        }
    }
}