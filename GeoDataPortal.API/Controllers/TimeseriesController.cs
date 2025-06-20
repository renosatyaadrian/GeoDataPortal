using GeoDataPortal.Application.DTOs.Timeseries;
using GeoDataPortal.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GeoDataPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeseriesController : Controller
    {
        private readonly ITimeseriesService _timeseriesService;

        public TimeseriesController(ITimeseriesService timeseriesService)
        {
            _timeseriesService = timeseriesService;
        }

        [HttpGet("{geoDataId}")]
        public async Task<IActionResult> GetAllByGeoDataId(Guid geoDataId)
        {
            var timeseries = await _timeseriesService.GetTimeseriesByGeoDataIdAsync(geoDataId);
            return Ok(timeseries);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTimeseries([FromBody] AddUpdateTimeseriesDto timeseries)
        {
            await _timeseriesService.AddTimeseriesAsync(timeseries);
            return CreatedAtAction(nameof(CreateTimeseries), new { id = timeseries.Id }, timeseries);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTimeseries(Guid id, [FromBody] AddUpdateTimeseriesDto timeseries)
        {
            if (id != timeseries.Id)
                return BadRequest();

            await _timeseriesService.UpdateTimeseriesAsync(timeseries);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeseries(Guid id)
        {
            await _timeseriesService.DeleteTimeseriesAsync(id);
            return NoContent();
        }
    }
}