using GeoDataPortal.Domain.Entities;

namespace GeoDataPortal.Application.Persistence.Mssql
{
    public interface IUserService
    {
        Task<User?> GetUserByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
    }
}