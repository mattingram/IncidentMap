using IncidentMap.Models;

namespace IncidentMap.Services
{
    public interface IWeatherService
    {
        int GetWeatherCode(Location location, DateTime date);
    }
}