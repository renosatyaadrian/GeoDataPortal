using System.ComponentModel.DataAnnotations;

namespace GeoDataPortal.UI.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; } = "";

        [Required, EmailAddress]
        public string Email { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
