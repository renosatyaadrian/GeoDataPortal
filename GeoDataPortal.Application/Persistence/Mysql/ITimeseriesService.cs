using GeoDataPortal.Domain.Entities;

namespace GeoDataPortal.Application.Persistence.Mysql
{
    public interface ITimeseriesService
    {
        Task<IEnumerable<Timeseries>> GetTimeseriesByGeoDataIdAsync(Guid geoDataId);
        Task AddTimeseriesAsync(Timeseries timeseries);
    }
}