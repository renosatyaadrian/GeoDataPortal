using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GeoDataPortal.Application.Persistence.Mysql;
using GeoDataPortal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        public async Task<IActionResult> CreateTimeseries([FromBody] Timeseries timeseries)
        {
            await _timeseriesService.AddTimeseriesAsync(timeseries);
            return CreatedAtAction(nameof(CreateTimeseries), new { id = timeseries.Id }, timeseries);
        }
    }
}