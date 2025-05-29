namespace GeoDataPortal.Application.DTOs.GeoData
{
    public class GeoDataDetailDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; } 
        public required string GeoJson { get; set; }
    }
}