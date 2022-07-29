namespace IncidentMap.Services.Models
{
    public class Weather
    {
        public TempData[] Data { get; set; }

        public class TempData {
            public double Temp {get; set;}
            public double Prcp {get; set;}
            public int Coco {get; set;}
        }        
    }
}