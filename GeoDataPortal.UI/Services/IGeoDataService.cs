using GeoDataPortal.UI.Models;

namespace GeoDataPortal.UI.Services
{
    public interface IGeoDataService
    {
        Task<List<GeoData>> GetAllAsync();
        Task<GeoData?> GetByIdAsync(Guid id);
    }
}