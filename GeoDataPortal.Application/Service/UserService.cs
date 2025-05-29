using GeoDataPortal.Application.Interface;
using GeoDataPortal.Domain.Entities;
using GeoDataPortal.Domain.Interfaces;

namespace GeoDataPortal.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task AddUserAsync(User user)
        {
            return _userRepository.AddAsync(user);
        }

        public Task DeleteUserAsync(Guid id)
        {
            return _userRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return _userRepository.GetAllAsync();
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            return _userRepository.GetByEmailAsync(email);
        }

        public Task<User?> GetUserByIdAsync(Guid id)
        {
            return _userRepository.GetByIdAsync(id);
        }

        public Task UpdateUserAsync(User user)
        {
            return _userRepository.UpdateAsync(user);
        }
    }
}