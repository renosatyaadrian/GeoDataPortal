using GeoDataPortal.Domain.Interfaces;
using GeoDataPortal.Infrastructure.Context;
using GeoDataPortal.Infrastructure.Persistence.Mssql;
using GeoDataPortal.Infrastructure.Persistence.Mysql;
using GeoDataPortal.Infrastructure.Persistence.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GeoDataPortal.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<MssqlDbContext>(opt =>
            opt.UseSqlServer(config.GetConnectionString("MssqlConnection")));

        services.AddDbContext<PostgresDbContext>(opt =>
            opt.UseNpgsql(config.GetConnectionString("PostgresConnection")));

        services.AddDbContext<MysqlDbContext>(opt =>
            opt.UseMySql(config.GetConnectionString("MysqlConnection"),
                new MySqlServerVersion(new Version(8, 0, 36))));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IGeoDataRepository, GeoDataRepository>();
        services.AddScoped<ITimeseriesRepository, TimeseriesRepository>();

        return services;
    }
}
