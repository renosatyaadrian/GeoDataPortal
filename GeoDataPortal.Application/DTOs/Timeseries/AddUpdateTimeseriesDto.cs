using System.ComponentModel.DataAnnotations;

namespace GeoDataPortal.Application.DTOs.Timeseries
{
    public class AddUpdateTimeseriesDto
    {
        public Guid? Id { get; set; }
        
        [Required(ErrorMessage = "GeoData ID is required.")]
        public required Guid GeoDataId { get; set; }

        [Required(ErrorMessage = "Timestamp is required.")]
        public required DateTime Timestamp { get; set; }

        [Required(ErrorMessage = "Value is required.")]
        [Range(double.MinValue, double.MaxValue, ErrorMessage = "Value must be a valid number.")] // Atau Range spesifik
        public required double Value { get; set; }

        [StringLength(50, ErrorMessage = "Type cannot exceed 50 characters.")]
        public string? Type { get; set; }

        [StringLength(20, ErrorMessage = "Unit cannot exceed 20 characters.")]
        public string? Unit { get; set; }
    }
}