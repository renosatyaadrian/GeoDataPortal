using GeoDataPortal.Application.DTOs.Users;
using GeoDataPortal.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GeoDataPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string value)
        {
            if (string.IsNullOrEmpty(value)) return BadRequest("Email is required.");

            var user = await _userService.GetByEmailAsync(value);

            if (user == null) return NotFound("User not found.");

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] AddUpdateUserDto user)
        {
            var existingUser = await _userService.GetByEmailAsync(user.Email);
            if (existingUser != null)
            {
                return Conflict(new { message = $"User with email '{user.Email}' already exists." });
            }
            await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(CreateUser), new { id = user.Id }, user);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] AddUpdateUserDto user)
        {
            if (id != user.Id)
                return BadRequest();

            var existingUser = await _userService.GetByEmailAsync(user.Email);
            if (existingUser != null)
            {
                return Conflict(new { message = $"User with email '{user.Email}' already exists." });
            }

            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}