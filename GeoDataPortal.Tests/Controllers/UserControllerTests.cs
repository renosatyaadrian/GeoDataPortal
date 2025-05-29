using GeoDataPortal.API.Controllers;
using GeoDataPortal.Application.Interface;
using GeoDataPortal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GeoDataPortal.Tests.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly UserController _controller;
        private readonly string username = "usernametest";
        private readonly string email = "test@example.com";
        private readonly DateTime createdAt = new(2024, 1, 1);

        public UserControllerTests()
        {
            _mockUserService = new Mock<IUserService>();
            _controller = new UserController(_mockUserService.Object);
        }

        [Fact]
        public async Task GetUserById_ReturnsOk()
        {
            // Arrange
            var expectedUsers = new User
            {
                Id = new Guid(),
                Email = email,
                Username = username,
                CreatedAt = createdAt
                
            };

            _mockUserService.Setup(s => s.GetUserByIdAsync(expectedUsers.Id))
                .ReturnsAsync(expectedUsers);

            // Act
            var result = await _controller.GetUser(expectedUsers.Id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var user = Assert.IsType<User>(okResult.Value);
            Assert.Equal(username, user.Username);
        }

        [Fact]
        public async Task GetAllUser_ReturnsOk()
        {
            // Arrange
            var expectedUsers = new List<User>
            {
                new User()
                {
                    Id = new Guid(),
                    Email = email,
                    Username = username,
                    CreatedAt = createdAt
                }
            };

            _mockUserService.Setup(s => s.GetAllUsersAsync())
                .ReturnsAsync(expectedUsers);
            // Act
            var result = await _controller.GetAllUser();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var users = Assert.IsType<List<User>>(okResult.Value);
            Assert.Equal(expectedUsers.Count, users.Count);
        }

        [Fact]
        public async Task GetUserByEmail_ReturnsOk()
        {
            // Arrange
            var expectedUser = new User
            {
                Id = new Guid(),
                Email = email,
                Username = username,
                CreatedAt = createdAt
            };

            _mockUserService.Setup(s => s.GetByEmailAsync(email))
                .ReturnsAsync(expectedUser);

            // Act
            var result = await _controller.GetByEmail(email);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var user = Assert.IsType<User>(okResult.Value);
            Assert.Equal(email, user.Email);
        }

        [Fact]
        public async Task CreateUser_Success()
        {
            // Arrange
            var user = new User { Id = Guid.NewGuid(), Username = username };

            // Act
            var result = await _controller.CreateUser(user);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(_controller.CreateUser), createdResult.ActionName);
            Assert.Equal(user, createdResult.Value);

            _mockUserService.Verify(s => s.AddUserAsync(user), Times.Once);
        }

        [Fact]
        public async Task UpdateUser_Success()
        {
            // Arrange
            var user = new User { Id = Guid.NewGuid(), Username = "Updated User" };

            // Act
            var result = await _controller.UpdateUser(user.Id, user);

            // Assert
            Assert.IsType<NoContentResult>(result);
            _mockUserService.Verify(s => s.UpdateUserAsync(user), Times.Once);
        }

        [Fact]
        public async Task DeleteUser_Success()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var result = await _controller.DeleteUser(id);

            // Assert
            Assert.IsType<NoContentResult>(result);
            _mockUserService.Verify(s => s.DeleteUserAsync(id), Times.Once);
        }
    }
}