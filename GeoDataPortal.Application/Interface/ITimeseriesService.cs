using GeoDataPortal.Application.DTOs.Timeseries;

namespace GeoDataPortal.Application.Interface
{
    public interface ITimeseriesService
    {
        Task<IEnumerable<TimeseriesDetailDto>> GetTimeseriesByGeoDataIdAsync(Guid geoDataId);
        Task AddTimeseriesAsync(AddUpdateTimeseriesDto timeseries);
        Task UpdateTimeseriesAsync(AddUpdateTimeseriesDto timeseries);
        Task DeleteTimeseriesAsync(Guid id);
    }
}