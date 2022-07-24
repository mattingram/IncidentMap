using IncidentMap.Models;

namespace IncidentMap.Services
{
    public interface IIncidentService
    {
        Incident GetIncidentFromFile(string filePath);
    }
}