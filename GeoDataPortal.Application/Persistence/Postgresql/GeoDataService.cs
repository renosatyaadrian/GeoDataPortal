using GeoDataPortal.Domain.Entities;
using GeoDataPortal.Domain.Interfaces;

namespace GeoDataPortal.Application.Persistence.Postgresql
{
    public class GeoDataService : IGeoDataService
    {
        private readonly IGeoDataRepository _geoDataRepository;

        public GeoDataService(IGeoDataRepository geoDataRepository)
        {
            _geoDataRepository = geoDataRepository;
        }

        public Task AddGeodataAsync(GeoData geoData)
        {
            return _geoDataRepository.AddAsync(geoData);
        }

        public Task<IEnumerable<GeoData>> GetAllGeoDataAsync()
        {
            return _geoDataRepository.GetAllAsync();
        }

        public Task<GeoData?> GetGeoDataByIdAsync(Guid id)
        {
            return _geoDataRepository.GetByIdAsync(id);
        }
    }
}