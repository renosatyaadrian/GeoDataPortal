namespace GeoDataPortal.Application.DTOs.Users
{
    public class UserDetailDto
    {
        public required Guid Id { get; set; } 
        public required string Username { get; set; }
        public required string Email { get; set; }
    }
}