using GeoDataPortal.Application.Persistence.Mssql;
using GeoDataPortal.Application.Persistence.Mysql;
using Microsoft.Extensions.DependencyInjection;

namespace GeoDataPortal.Application
{
    public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITimeseriesService, TimeseriesService>();

        return services;
    }
}
}