using GeoDataPortal.Application.Persistence.Postgresql;
using GeoDataPortal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GeoDataPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeoDataController : ControllerBase
    {
        private readonly IGeoDataService _geoDataService;

        public GeoDataController(IGeoDataService geoDataService)
        {
            _geoDataService = geoDataService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var geoData = await _geoDataService.GetGeoDataByIdAsync(id);
            if (geoData == null) return NotFound("GeoData Not Found.");

            return Ok(geoData);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGeoData()
        {
            var geoDatas = await _geoDataService.GetAllGeoDataAsync();
            return Ok(geoDatas);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGeoData([FromBody] GeoData geoData)
        {
            await _geoDataService.AddGeodataAsync(geoData);
            return CreatedAtAction(nameof(CreateGeoData), new { id = geoData.Id }, geoData);
        }
    }
}