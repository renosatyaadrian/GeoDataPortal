using GeoDataPortal.UI.Services;

namespace GeoDataPortal.UI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddGeoDataPortalHttpClients(this IServiceCollection services, Uri baseAddress)
        {
            services.AddHttpClient<IUserService, UserService>(client => client.BaseAddress = baseAddress);
            services.AddHttpClient<IGeoDataService, GeoDataService>(client => client.BaseAddress = baseAddress);
            services.AddHttpClient<ITimeseriesService, TimeseriesService>(client => client.BaseAddress = baseAddress);
        }
    }
}