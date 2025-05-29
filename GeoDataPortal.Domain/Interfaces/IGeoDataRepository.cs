using GeoDataPortal.Domain.Entities;

namespace GeoDataPortal.Domain.Interfaces
{
    public interface IGeoDataRepository
    {
        Task<GeoData?> GetByIdAsync(Guid id);
        Task<IEnumerable<GeoData>> GetAllAsync();
        Task AddAsync(GeoData geoData);
        Task UpdateAsync(GeoData geoData);
        Task DeleteAsync(Guid id);
    }
}