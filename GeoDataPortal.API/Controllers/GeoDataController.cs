using GeoDataPortal.Application.DTOs.GeoData;
using GeoDataPortal.Application.Interface;
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
        public async Task<IActionResult> CreateGeoData([FromBody] AddUpdateGeoDataDto geoData)
        {
            await _geoDataService.AddGeodataAsync(geoData);
            return CreatedAtAction(nameof(CreateGeoData), new { id = geoData.Id }, geoData);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGeoData(Guid id, [FromBody] AddUpdateGeoDataDto geoData)
        {
            if (id != geoData.Id)
                return BadRequest();

            await _geoDataService.UpdateGeoDataAsync(geoData);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeoData(Guid id)
        {
            await _geoDataService.DeleteGeoDataAsync(id);
            return NoContent();
        }
    }
}