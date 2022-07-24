using IncidentMap.Models;

namespace IncidentMap.Services
{
    public class WeatherService : IWeatherService
    {
        private IConfiguration _configuration;
        public WeatherService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int GetWeatherCode(Location location, DateTime dateTime)
        {
            string weatherApiKey = _configuration["WeatherApiKey"];
            if (string.IsNullOrEmpty(weatherApiKey))
            {
                throw new Exception("WeatherApiKey is not configured. Please set the configuration key in the appsettings.json file.");
            }
            string date = dateTime.ToString("YYYY-MM-DD");

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://meteostat.p.rapidapi.com/point/hourly?lat={location.Lat}&lon={location.Lng}&start={date}&end={date}&tz=America%2FToronto"),
                Headers =
                {
                    { "X-RapidAPI-Key", weatherApiKey },
                    { "X-RapidAPI-Host", "meteostat.p.rapidapi.com" },
                },
            };
            using (var response = client.SendAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                var body = response.Content.ReadFromJsonAsync<dynamic>().Result;
                if (body.data && body.data[dateTime.Hour])
                {
                    return body.data[dateTime.Hour].coco;
                }
            }
            return -1;
        }
    }
}