using GeoDataPortal.Domain.Entities;
using GeoDataPortal.Domain.Interfaces;
using GeoDataPortal.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GeoDataPortal.Infrastructure.Persistence.Mysql
{
    public class TimeseriesRepository : ITimeseriesRepository
    {
        private readonly MysqlDbContext _dbContext;

        public TimeseriesRepository(MysqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Timeseries timeseries)
        {
            _dbContext.Timeseries.Add(timeseries);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Timeseries>> GetByGeoDataIdAsync(Guid geoDataId)
        {
            return await _dbContext.Timeseries
                .Where(t => t.GeoDataId == geoDataId)
                .OrderByDescending(u => u.CreatedAt)
                .ToListAsync();
        }
    }
}