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
    }
}