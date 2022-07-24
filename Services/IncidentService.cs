using IncidentMap.Models;

namespace IncidentMap.Services
{
    public class IncidentService : IIncidentService
    {
        public Incident GetIncidentFromFile(string filePath)
        {            
            string jsonString = File.ReadAllText(filePath);
            dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);
            if (json == null)
            {
                return new Incident();
            }
            var incident = new Incident();
            incident.Address = new Location {Lat = json.address.latitude, Lng = json.address.longitude};
            incident.FireDepartment = json.fire_department.name;
            incident.EventDate = json.description.event_opened;
            // incident.Apparatus = new List<Apparatus>();
            // foreach(var apparatus in json.apparatus)
            // {
            //     var a = new Apparatus { Type = apparatus.unit_type };
            //     incident.Apparatus.Append(a);
            // }

            return incident;            
        }
    }
}