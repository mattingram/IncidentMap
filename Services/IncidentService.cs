using IncidentMap.Models;

namespace IncidentMap.Services
{
    public class IncidentService : IIncidentService
    {
        public Incident GetIncidentFromFile(string filePath)
        {            
            string jsonString = File.ReadAllText(filePath);
            dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);
            var incident = new Incident();
            incident.Address = new Location {Lat = json.address.latitude, Lon = json.address.longitude};

            return incident;            
        }
    }
}