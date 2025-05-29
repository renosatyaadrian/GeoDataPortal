using GeoDataPortal.UI.Models;
using GeoDataPortal.UI.Services;

public class GeoDataService : IGeoDataService
{
    private readonly HttpClient _httpClient;

    public GeoDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<GeoData>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<GeoData>>("api/geodata") ?? new List<GeoData>();
    }

    public async Task<GeoData?> GetByIdAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<GeoData>($"api/geodata/{id}");
    }
}