using GeoDataPortal.Domain.Entities;
using GeoDataPortal.Domain.Interfaces;

namespace GeoDataPortal.Application.Persistence.Mysql
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

        public Task<IEnumerable<Timeseries>> GetTimeseriesByGeoDataIdAsync(Guid geoDataId)
        {
            return _timeseriesRepository.GetByGeoDataIdAsync(geoDataId);
        }
    }
}