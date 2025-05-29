namespace GeoDataPortal.Application.DTOs.Timeseries
{
    public class TimeseriesDetailDto
    {
        public Guid Id { get; set; }
        public required Guid GeoDataId { get; set; }
        public required DateTime Timestamp { get; set; }
        public required double Value { get; set; }
        public string? Type { get; set; }
        public string? Unit { get; set; }
    }
}