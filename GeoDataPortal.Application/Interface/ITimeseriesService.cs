using GeoDataPortal.Domain.Entities;

namespace GeoDataPortal.Application.Interface
{
    public interface ITimeseriesService
    {
        Task<IEnumerable<Timeseries>> GetTimeseriesByGeoDataIdAsync(Guid geoDataId);
        Task AddTimeseriesAsync(Timeseries timeseries);
        Task UpdateTimeseriesAsync(Timeseries timeseries);
        Task DeleteTimeseriesAsync(Guid id);
    }
}