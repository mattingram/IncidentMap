using IncidentMap.Models;

namespace IncidentMap.Services
{
    public interface IWeatherService
    {
        Weather GetWeather(Location location, DateTime date);
    }
}