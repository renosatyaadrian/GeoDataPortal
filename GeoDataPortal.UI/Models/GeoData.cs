namespace GeoDataPortal.UI.Models
{
    public class GeoData
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string GeoJson { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}