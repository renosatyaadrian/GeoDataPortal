using GeoDataPortal.Application.DTOs.GeoData;
using GeoDataPortal.Application.Interface;
using GeoDataPortal.Domain.Entities;
using GeoDataPortal.Domain.Interfaces;

namespace GeoDataPortal.Application.Service
{
    public class GeoDataService : IGeoDataService
    {
        private readonly IGeoDataRepository _geoDataRepository;

        public GeoDataService(IGeoDataRepository geoDataRepository)
        {
            _geoDataRepository = geoDataRepository;
        }

        public Task AddGeodataAsync(AddUpdateGeoDataDto input)
        {
            var newGeoData = new GeoData
            {
                GeoJson = input.GeoJson,
                Name = input.Name
            };
            return _geoDataRepository.AddAsync(newGeoData);
        }

        public Task DeleteGeoDataAsync(Guid id)
        {
            return _geoDataRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<GeoDataDetailDto>> GetAllGeoDataAsync()
        {
            var geoDatas = await _geoDataRepository.GetAllAsync();
            return geoDatas
                .Select(g => new GeoDataDetailDto
                {
                    Id = g.Id,
                    GeoJson = g.GeoJson,
                    Name = g.Name
                })
                .ToList();
        }

        public async Task<GeoDataDetailDto?> GetGeoDataByIdAsync(Guid id)
        {
            var geoData = await _geoDataRepository.GetByIdAsync(id);
            if (geoData != null)
            {
                return new GeoDataDetailDto
                {
                    Id = geoData.Id,
                    GeoJson = geoData.GeoJson,
                    Name = geoData.Name
                };
            }
            return null;
        }

        public Task UpdateGeoDataAsync(AddUpdateGeoDataDto geoData)
        {
            var updatedGeoData = new GeoData
            {
                Id = geoData.Id!.Value,
                GeoJson = geoData.GeoJson,
                Name = geoData.Name
            };
            return _geoDataRepository.UpdateAsync(updatedGeoData);
        }
    }
}