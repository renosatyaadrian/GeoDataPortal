using System.ComponentModel.DataAnnotations;

namespace GeoDataPortal.Application.DTOs.GeoData
{
    public class AddUpdateGeoDataDto
    {
        public Guid? Id { get; set; }
        
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "GeoJSON data is required.")]
        public required string GeoJson { get; set; }
    }
}