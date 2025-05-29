using GeoDataPortal.Application.Interface;
using GeoDataPortal.Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace GeoDataPortal.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITimeseriesService, TimeseriesService>();
            services.AddScoped<IGeoDataService, GeoDataService>();

            return services;
        }
    }
}