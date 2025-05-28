using GeoDataPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeoDataPortal.Infrastructure.Context
{
    public class MysqlDbContext(DbContextOptions<MysqlDbContext> options) : DbContext(options)
    {
        public DbSet<Timeseries> Timeseries => Set<Timeseries>();
    }
}