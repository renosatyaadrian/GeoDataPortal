using GeoDataPortal.Domain.Entities;

namespace GeoDataPortal.Application.Interface
{
    public interface IGeoDataService
    {
        Task<GeoData?> GetGeoDataByIdAsync(Guid id);
        Task<IEnumerable<GeoData>> GetAllGeoDataAsync();
        Task AddGeodataAsync(GeoData geoData);
        Task UpdateGeoDataAsync(GeoData geoData);
        Task DeleteGeoDataAsync(Guid id);
    }
}