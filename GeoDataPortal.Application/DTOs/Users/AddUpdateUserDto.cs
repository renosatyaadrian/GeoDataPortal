using System.ComponentModel.DataAnnotations;

namespace GeoDataPortal.Application.DTOs.Users
{
    public class AddUpdateUserDto
    {
        public Guid? Id { get; set; }
        
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public required string Email { get; set; }
    }
}