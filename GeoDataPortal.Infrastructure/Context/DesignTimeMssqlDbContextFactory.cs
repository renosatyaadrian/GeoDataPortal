using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GeoDataPortal.Infrastructure.Context
{
    public class DesignTimeMssqlDbContextFactory : IDesignTimeDbContextFactory<MssqlDbContext>
    {
        public MssqlDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "GeoDataPortal.API"))
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MssqlDbContext>();
            var connectionString = configuration.GetConnectionString("MssqlConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new MssqlDbContext(optionsBuilder.Options);
        }
    }
}
