using IncidentMap.Services;
using IncidentMap.Services.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class WeatherServiceTests
{
    private readonly IConfiguration _config;
    private readonly IWeatherService _service;

    public WeatherServiceTests()
    {
        _config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        _service = new WeatherService(_config);
    }

    [Test]
    public void GetsAndDeserializesWeatherData()
    {    
        var location = new Location{ Lat = 45, Lng = -75};
        var time = DateTime.Now;
        var result = _service.GetWeather(location, time);
        
        Assert.That(result?.Data, Is.Not.Null);
        Assert.That(result?.Data.Length, Is.GreaterThan(0));
        Assert.That(result?.Data[0].Temp, Is.GreaterThan(0));
        Console.WriteLine($"{result?.Data[0].Temp}");
    }
}