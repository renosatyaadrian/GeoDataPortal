using GeoDataPortal.Application.DTOs.Users;

namespace GeoDataPortal.Application.Interface
{
    public interface IUserService
    {
        Task<UserDetailDto?> GetUserByIdAsync(Guid id);
        Task<IEnumerable<UserDetailDto>> GetAllUsersAsync();
        Task<UserDetailDto?> GetByEmailAsync(string email);
        Task AddUserAsync(AddUpdateUserDto user);
        Task UpdateUserAsync(AddUpdateUserDto user);
        Task DeleteUserAsync(Guid id);
    }
}