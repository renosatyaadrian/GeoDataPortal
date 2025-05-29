using GeoDataPortal.UI.Models;

namespace GeoDataPortal.UI.Services
{
    public interface ITimeseriesService
    {
        Task<IEnumerable<Timeseries>?> GetTimeseriesByGeoDataIdAsync(Guid geoDataId);
        Task<bool> CreateTimeseriesAsync(Timeseries timeseries);
        Task<bool> UpdateTimeseriesAsync(Timeseries timeseries);
        Task<bool> DeleteTimeseriesAsync(Guid id);
    }
}