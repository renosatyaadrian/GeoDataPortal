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

        public Task AddTimeseriesAsync(Timeseries timeseries)
        {
            return _timeseriesRepository.AddAsync(timeseries);
        }

        public Task DeleteTimeseriesAsync(Guid id)
        {
            return _timeseriesRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<Timeseries>> GetTimeseriesByGeoDataIdAsync(Guid geoDataId)
        {
            return _timeseriesRepository.GetByGeoDataIdAsync(geoDataId);
        }

        public Task UpdateTimeseriesAsync(Timeseries timeseries)
        {
            return _timeseriesRepository.UpdateAsync(timeseries);
        }
    }
}