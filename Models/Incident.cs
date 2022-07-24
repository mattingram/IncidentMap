namespace IncidentMap.Models
{
    public class Location
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class UnitStatus
    {
        public string StatusType { get; set; }
        public Location Location { get; set; }
        public DateTime? Time { get; set; }
    }

    public class Apparatus
    {
        public string Station { get; set; }
        public string Unit { get; set; }
        public string Type { get; set; }
        public List<UnitStatus> Status { get; set; }
    }

    public class Incident
    {
        public Location Location { get; set; }
        public string Address {get; set;}
        public string Description { get; set; }
        public IEnumerable<Apparatus> Apparatus { get; set; }
        public DateTime? EventDate { get; set; }
        public string FireDepartment { get; set; }
    }
}