using GeoDataPortal.UI.Models;
using GeoDataPortal.UI.Services;

public class TimeseriesService : ITimeseriesService
{
    private readonly HttpClient _httpClient;

    public TimeseriesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> CreateTimeseriesAsync(Timeseries timeseries)
    {
        var response = await _httpClient.PostAsJsonAsync("api/timeseries", timeseries);

        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        return false;
    }

    public async Task<bool> DeleteTimeseriesAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/timeseries/{id}");

        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        return false;
    }

    public async Task<List<Timeseries>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Timeseries>>("api/timeseries") ?? new List<Timeseries>();
    }

    public async Task<IEnumerable<Timeseries>?> GetTimeseriesByGeoDataIdAsync(Guid geoDataId)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Timeseries>>($"api/timeseries/{geoDataId}");
    }

    public async Task<bool> UpdateTimeseriesAsync(Timeseries updatedTimeseries)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/timeseries/{updatedTimeseries.Id}", updatedTimeseries);

        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        return false;
    }
}