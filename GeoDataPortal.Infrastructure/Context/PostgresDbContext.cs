using GeoDataPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeoDataPortal.Infrastructure.Context
{
    public class PostgresDbContext(DbContextOptions<PostgresDbContext> options) : DbContext(options)
    {
        public DbSet<GeoData> GeoDatas => Set<GeoData>();
    }
}