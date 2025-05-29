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

        public async Task DeleteAsync(Guid id)
        {
            var timeseries = await _dbContext.Timeseries.FindAsync(id);
            if (timeseries != null)
            {
                _dbContext.Timeseries.Remove(timeseries);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Timeseries>> GetByGeoDataIdAsync(Guid geoDataId)
        {
            return await _dbContext.Timeseries
                .Where(t => t.GeoDataId == geoDataId)
                .OrderByDescending(u => u.Timestamp)
                .ToListAsync();
        }

        public async Task UpdateAsync(Timeseries timeseries)
        {
            var existingTimeseries = await _dbContext.Timeseries.FindAsync(timeseries.Id);
            if (existingTimeseries != null)
            {
                existingTimeseries.GeoDataId = timeseries.GeoDataId;
                existingTimeseries.Timestamp = timeseries.Timestamp;
                existingTimeseries.Type = timeseries.Type;
                existingTimeseries.Unit = timeseries.Unit;
                existingTimeseries.Value = timeseries.Value;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}