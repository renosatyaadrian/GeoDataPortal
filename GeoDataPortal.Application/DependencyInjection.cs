using GeoDataPortal.Application.Persistence.Mssql;
using Microsoft.Extensions.DependencyInjection;

namespace GeoDataPortal.Application
{
    public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
}