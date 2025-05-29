using GeoDataPortal.Application.DTOs.Users;
using GeoDataPortal.Application.Service;
using GeoDataPortal.Domain.Entities;
using GeoDataPortal.Domain.Interfaces;
using Moq;

namespace GeoDataPortal.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _userService = new UserService(_mockUserRepository.Object);
        }

        [Fact]
        public async Task AddUserAsync_CalledRepositoryOnce()
        {
            // Arrange
            var inputDto = new AddUpdateUserDto
            {
                Email = "test@email.com",
                Username = "testusername"
            };

            _mockUserRepository.Setup(u => u.AddAsync(It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            // Act
            await _userService.AddUserAsync(inputDto);

            // Assert
            _mockUserRepository.Verify(u => u.AddAsync(It.Is<User>(
                u => u.Email == inputDto.Email &&
                     u.Username == inputDto.Username)), Times.Once);
        }

        [Fact]
        public async Task DeleteUserAsync_CalledRepositoryOnce()
        {
            // Arrange
            var userId = new Guid();

            _mockUserRepository.Setup(u => u.DeleteAsync(It.IsAny<Guid>()))
                .Returns(Task.CompletedTask);

            // Act
            await _userService.DeleteUserAsync(userId);

            // Assert
            _mockUserRepository.Verify(u => u.DeleteAsync(userId), Times.Once);
        }

        [Fact]
        public async Task GetAllUsersAsync_Found()
        {
            // Arrange
            var userList = new List<User>
            {
                new() { Id = Guid.NewGuid(), Email = "test@email.com", Username = "testusername"},
                new() { Id = Guid.NewGuid(), Email = "test2@email.com", Username = "testusername2"}
            };

            _mockUserRepository.Setup(r => r.GetAllAsync())
                .ReturnsAsync(userList);

            // Act
            var result = await _userService.GetAllUsersAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userList.Count, result.Count()); 
            
            foreach (var original in userList)
            {
                var mapped = result.FirstOrDefault(dto => dto.Id == original.Id);
                Assert.NotNull(mapped);
                Assert.Equal(original.Email, mapped.Email);
                Assert.Equal(original.Username, mapped.Username);
            }
            
            _mockUserRepository.Verify(r => r.GetAllAsync(), Times.Once());
        }

        [Fact]
        public async Task GetUserByIdAsync_Found()
        {
            // Arrange
            var userId = new Guid();
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "test@email.com",
                Username = "testusername"
            };
            
            _mockUserRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(user);

            // Act
            var result = await _userService.GetUserByIdAsync(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Email, result.Email);
            Assert.Equal(user.Username, result.Username);
            
            _mockUserRepository.Verify(r => r.GetByIdAsync(userId), Times.Once());
        }

        [Fact]
        public async Task GetUserByIdAsync_NotFound()
        {
            // Arrange
            var userId = new Guid();
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "test@email.com",
                Username = "testusername"
            };
            
            _mockUserRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((User?)null);

            // Act
            var result = await _userService.GetUserByIdAsync(userId);

            // Assert
            Assert.Null(result);

            _mockUserRepository.Verify(r => r.GetByIdAsync(userId), Times.Once());
        }

        [Fact]
        public async Task GetUserByEmailAsync_Found()
        {
            // Arrange
            var userEmail = "test@email.com";
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "test@email.com",
                Username = "testusername"
            };
            
            _mockUserRepository.Setup(r => r.GetByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(user);

            // Act
            var result = await _userService.GetByEmailAsync(userEmail);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Email, result.Email);
            Assert.Equal(user.Username, result.Username);
            
            _mockUserRepository.Verify(r => r.GetByEmailAsync(userEmail), Times.Once());
        }

        [Fact]
        public async Task GetUserByEmailAsync_NotFound()
        {
            // Arrange
            var userEmail = "test@email.com";
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "test@email.com",
                Username = "testusername"
            };
            
            _mockUserRepository.Setup(r => r.GetByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((User?)null);

            // Act
            var result = await _userService.GetByEmailAsync(userEmail);

            // Assert
            Assert.Null(result);
            
            _mockUserRepository.Verify(r => r.GetByEmailAsync(userEmail), Times.Once());
        }

        [Fact]
        public async Task UpdateUserAsync_CalledRepositoryOnce()
        {
            // Arrange
            var inputDto = new AddUpdateUserDto
            {
                Id = new Guid(),
                Email = "test@email.com",
                Username = "testusername"
            };

            _mockUserRepository.Setup(u => u.UpdateAsync(It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            // Act
            await _userService.UpdateUserAsync(inputDto);

            // Assert
            _mockUserRepository.Verify(u => u.UpdateAsync(It.Is<User>(
                u => u.Email == inputDto.Email &&
                     u.Username == inputDto.Username)), Times.Once);
        }
    }
}