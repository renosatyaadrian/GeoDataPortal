using GeoDataPortal.Application.DTOs.GeoData;

namespace GeoDataPortal.Application.Interface
{
    public interface IGeoDataService
    {
        Task<GeoDataDetailDto?> GetGeoDataByIdAsync(Guid id);
        Task<IEnumerable<GeoDataDetailDto>> GetAllGeoDataAsync();
        Task AddGeodataAsync(AddUpdateGeoDataDto geoData);
        Task UpdateGeoDataAsync(AddUpdateGeoDataDto geoData);
        Task DeleteGeoDataAsync(Guid id);
    }
}