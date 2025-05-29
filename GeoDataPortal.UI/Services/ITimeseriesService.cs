using GeoDataPortal.UI.Models;

namespace GeoDataPortal.UI.Services
{
    public interface ITimeseriesService
    {
        Task<IEnumerable<Timeseries>?> GetTimeseriesByGeoDataIdAsync(Guid geoDataId);
        Task<bool> AddTimeseriesAsync(Timeseries timeseries);
    }
}