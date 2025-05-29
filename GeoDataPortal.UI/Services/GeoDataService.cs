using GeoDataPortal.UI.Models;
using GeoDataPortal.UI.Services;

public class GeoDataService : IGeoDataService
{
    private readonly HttpClient _httpClient;

    public GeoDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> CreateGeoDataAsync(GeoData geoData)
    {
        var response = await _httpClient.PostAsJsonAsync("api/geodata", geoData);

        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        return false;
    }

    public async Task<bool> DeleteGeoDataAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/geodata/{id}");

        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        return false;
    }

    public async Task<List<GeoData>> GetAllGeoDataAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<GeoData>>("api/geodata") ?? new List<GeoData>();
    }

    public async Task<GeoData?> GetGeoDataByIdAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<GeoData>($"api/geodata/{id}");
    }

    public async Task<bool> UpdateGeoDataAsync(GeoData updatedGeoData)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/geodata/{updatedGeoData.Id}", updatedGeoData);

        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        return false;
    }
}