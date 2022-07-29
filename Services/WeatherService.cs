using IncidentMap.Services.Models;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace IncidentMap.Services
{
    public class WeatherService : IWeatherService
    {
        private IConfiguration _configuration;

        public WeatherService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Weather GetWeather(Location location, DateTime dateTime)
        {
            string weatherApiKey = _configuration["WeatherApiKey"];
            if (string.IsNullOrEmpty(weatherApiKey))
            {
                throw new Exception("WeatherApiKey is not configured. Please set the configuration key in the appsettings.json file.");
            }

            string date = dateTime.ToString("yyyy-MM-dd");
            string dateAndHour = dateTime.ToString("yyyy-MM-dd HH:00:00");
            string url = $"https://meteostat.p.rapidapi.com/point/hourly?lat={location.Lat}&lon={location.Lng}&start={date}&end={date}&tz=America%2FToronto&units=imperial";
            
            Weather weather = new Weather();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    { "X-RapidAPI-Key", weatherApiKey },
                    { "X-RapidAPI-Host", "meteostat.p.rapidapi.com" },
                },
            };

            using (var response = client.SendAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                var body = response.Content.ReadAsStringAsync().Result;
                weather = JsonSerializer.Deserialize<Weather>(body, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true });
            }
            return weather;
        }
    }
}