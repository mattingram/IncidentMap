using IncidentMap.Models;
using IncidentMap.Services;
using Microsoft.AspNetCore.Mvc;

namespace IncidentMap.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MapController : ControllerBase
    {
        private readonly IMapService _mapService;
        private readonly IConfiguration _configuration;

        public MapController(IMapService mapService, IConfiguration configuration)
        {
            _mapService = mapService;
            _configuration = configuration;
        }

        [HttpGet]
        public MapData Get()
        {
            return _mapService.GetData();
        }
    }
}