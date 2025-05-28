using GeoDataPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeoDataPortal.Infrastructure.Context
{
    public class MssqlDbContext(DbContextOptions<MssqlDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
    }
}