using GeoDataPortal.Domain.Entities;

namespace GeoDataPortal.Application.Persistence.Postgresql
{
    public interface IGeoDataService
    {
        Task<GeoData?> GetGeoDataByIdAsync(Guid id);
        Task<IEnumerable<GeoData>> GetAllGeoDataAsync();
        Task AddGeodataAsync(GeoData geoData);
    }
}