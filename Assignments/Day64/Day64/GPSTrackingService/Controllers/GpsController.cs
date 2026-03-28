using GPSTrackingService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace GPSTrackingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class GpsController : ControllerBase
    {
        private readonly ILogger<GpsController> _logger;

        public GpsController(ILogger<GpsController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet]
        public IEnumerable<GpsData> Get()
        {
            var list = new List<GpsData>();
            for (int i = 1; i <= 5; i++)
            {
                var gps = new GpsData
                {
                    Id = i,
                    TruckNumber = "TR" + i,
                    Latitude = Random.Shared.NextDouble() * 180 - 90,
                    Longitude = Random.Shared.NextDouble() * 360 - 180
                };

                list.Add(gps);
            }
            return list;
        }
    }
}

