using GeoDataPortal.Domain.Common;

namespace GeoDataPortal.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}