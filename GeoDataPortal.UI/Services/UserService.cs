using GeoDataPortal.UI.Models;

namespace GeoDataPortal.UI.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<User>($"api/user/{id}");
        }

        public async Task<List<User>?> GetAllUser()
        {
            return await _httpClient.GetFromJsonAsync<List<User>>("api/user");
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var encodedEmail = Uri.EscapeDataString(email);
            var url = $"api/user/email?value={encodedEmail}";
            return await _httpClient.GetFromJsonAsync<User>(url);
        }

        public async Task<bool> CreateUserAsync(User newUser)
        {
            var response = await _httpClient.PostAsJsonAsync("api/user", newUser);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateUserAsync(User updatedUser)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/user/{updatedUser.Id}", updatedUser);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/user/{id}");
            
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}