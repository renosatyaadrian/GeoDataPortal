namespace GeoDataPortal.UI.Models
{
    public class Timeseries
    {
        public Guid Id { get; set; }
        public Guid GeoDataId { get; set; }
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}