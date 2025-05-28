using GeoDataPortal.Domain.Common;

namespace GeoDataPortal.Domain.Entities
{
    public class GeoData : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string GeoJson { get; set; } = default!;
    }
}