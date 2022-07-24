namespace IncidentMap.Models
{
    public class Location
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }

    public class UnitStatus
    {
        public string StatusType { get; set; }
        public Location Location { get; set; }
        public DateTime Time { get; set; }
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
        public Location Address { get; set; }
        public IEnumerable<Apparatus> Apparatus { get; set; }
        public DateTime EventDate { get; set; }
        public string FireDepartment { get; set; }
    }
}