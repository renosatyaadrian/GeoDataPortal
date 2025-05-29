using GeoDataPortal.Domain.Common;

namespace GeoDataPortal.Domain.Entities
{
    public class Timeseries : BaseEntity
    {
        public Guid GeoDataId { get; set; }
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }
        public string? Type { get; set; }
        public string? Unit { get; set; }
    }
}