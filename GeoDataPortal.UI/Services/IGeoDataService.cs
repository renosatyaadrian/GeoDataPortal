using GeoDataPortal.UI.Models;

namespace GeoDataPortal.UI.Services
{
    public interface IGeoDataService
    {
        Task<List<GeoData>> GetAllGeoDataAsync();
        Task<GeoData?> GetGeoDataByIdAsync(Guid id);
        Task<bool> CreateGeoDataAsync(GeoData geoData);
        Task<bool> UpdateGeoDataAsync(GeoData user);
        Task<bool> DeleteGeoDataAsync(Guid id);
    }
}