using GeoDataPortal.Application.DTOs.Users;
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
        public Task AddUserAsync(AddUpdateUserDto user)
        {
            var newUser = new User
            {
                Username = user.Username,
                Email = user.Email
            };

            return _userRepository.AddAsync(newUser);
        }

        public Task DeleteUserAsync(Guid id)
        {
            return _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserDetailDto>> GetAllUsersAsync()
        {
            var results = await _userRepository.GetAllAsync();

            return results
                .Select(r => new UserDetailDto
                {
                    Id = r.Id,
                    Email = r.Email,
                    Username = r.Username,
                })
                .ToList();
        }

        public async Task<UserDetailDto?> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user != null)
            {
                return new UserDetailDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Username = user.Username
                };
            }
            return null;
        }

        public async Task<UserDetailDto?> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                return new UserDetailDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Username = user.Username
                };
            }
            return null;
        }

        public Task UpdateUserAsync(AddUpdateUserDto user)
        {
            var updatedUser = new User
            {
                Id = user.Id!.Value,
                Email = user.Email,
                Username = user.Username,
            };
            return _userRepository.UpdateAsync(updatedUser);
        }
    }
}