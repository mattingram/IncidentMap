using IncidentMap.Services.Models;
using Microsoft.Extensions.Configuration;

namespace IncidentMap.Services
{
    public class MapService : IMapService
    {
        public IIncidentService _incidentService;
        public IWeatherService _weatherService;
        private readonly IConfiguration _configuration;

        public MapService(IIncidentService incidentService, IWeatherService weatherService, IConfiguration configuration)
        {
            _incidentService = incidentService;
            _weatherService = weatherService;
            _configuration = configuration;
        }

        public MapData GetData()
        {
            var inputFile = _configuration["InputFile"];
            if (string.IsNullOrEmpty(inputFile))
            {
                throw new Exception("InputFile is not configured. Please set the InputFile configuration key in the appsettings.json file.");
            }

            var incident = _incidentService.GetIncidentFromFile(inputFile);
            var mapData = new MapData();
            mapData.Incident = incident;

            mapData.Weather = _weatherService.GetWeather(incident.Location, incident.EventDate.GetValueOrDefault());
            
            return mapData;
        }
    }
}