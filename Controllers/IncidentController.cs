using IncidentMap.Models;
using IncidentMap.Services;
using Microsoft.AspNetCore.Mvc;

namespace IncidentMap.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _incidentService;
        private readonly IConfiguration _configuration;

        public IncidentController(IIncidentService incidentService, IConfiguration configuration)
        {
            _incidentService = incidentService;
            _configuration = configuration;
        }

        [HttpGet]
        public Incident GetIncident()
        {
            var inputFile = _configuration["InputFile"];
            if (string.IsNullOrEmpty(inputFile))
            {
                throw new Exception("InputFile is not configured. Please set the InputFile configuration key in the appsettings.json file.");
            }

            var incident = _incidentService.GetIncidentFromFile(inputFile);
            return incident;
        }
    }
}