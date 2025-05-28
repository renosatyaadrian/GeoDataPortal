using GeoDataPortal.Domain.Entities;

namespace GeoDataPortal.Domain.Interfaces
{
    public interface ITimeseriesRepository
    {
        Task<IEnumerable<Timeseries>> GetByGeoDataIdAsync(Guid geoDataId);
        Task AddAsync(Timeseries timeseries);
    }
}