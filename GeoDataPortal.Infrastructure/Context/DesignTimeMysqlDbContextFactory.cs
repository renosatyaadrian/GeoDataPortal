using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GeoDataPortal.Infrastructure.Context
{
    public class DesignTimeMySqlDbContextFactory : IDesignTimeDbContextFactory<MysqlDbContext>
    {
        public MysqlDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "GeoDataPortal.API"))
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MysqlDbContext>();
            var connectionString = configuration.GetConnectionString("MysqlConnection");

            // Ganti versi server sesuai kebutuhan
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new MysqlDbContext(optionsBuilder.Options);
        }
    }
}
