using GeoDataPortal.Domain.Entities;
using GeoDataPortal.Domain.Interfaces;
using GeoDataPortal.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GeoDataPortal.Infrastructure.Persistence.Postgres
{
    public class GeoDataRepository : IGeoDataRepository
    {
        private readonly PostgresDbContext _dbContext;

        public GeoDataRepository(PostgresDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(GeoData geoData)
        {
            _dbContext.Add(geoData);
            await _dbContext.SaveChangesAsync();
        }

        public async  Task DeleteAsync(Guid id)
        {
            var geoData = await _dbContext.GeoDatas.FindAsync(id);
            if (geoData != null)
            {
                _dbContext.GeoDatas.Remove(geoData);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<GeoData>> GetAllAsync()
        {
            return await _dbContext.GeoDatas
                .OrderByDescending(u => u.CreatedAt)
                .ToListAsync();
        }

        public async Task<GeoData?> GetByIdAsync(Guid id)
        {
            return await _dbContext.GeoDatas.FindAsync(id);
        }

        public async Task UpdateAsync(GeoData geoData)
        {
            var existingGeoData = await _dbContext.GeoDatas.FindAsync(geoData.Id);
            if (existingGeoData != null)
            {
                existingGeoData.GeoJson = geoData.GeoJson;
                existingGeoData.Name = geoData.Name;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}