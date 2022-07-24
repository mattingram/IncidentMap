# Incident Map

.NET web app that displays Fire Department incident data, enriches with weather data from https://dev.meteostat.net/ and displays incident data using Google Maps.

## Steps to Run

1. Ensure you have [.NET 6](https://dotnet.microsoft.com/en-us/download) installed
1. Configure the Google Maps Javascript API Key
    1. To get a Google Maps Javascript API Key, follow instructions here: https://developers.google.com/maps/documentation/javascript/cloud-setup
    1. Set the API key in appsettings.json
1. Configure Weather API Key
    1. Create a Weather API Key here: https://dev.meteostat.net/
    2. Set WeatherApiKey in appsettings.json
1. Configure path to InputFile in appsettings.json
1. In a terminal window: `dotnet run`

![Map output](/Map.png)

## Future Enhancements

I spent about 8 hours on this sample project. Using .NET to parse JSON felt very tedious and clunky. I think a better language would be Python or Node.js.

Improvements I would make if there was more time:
1. Add tests for the services to cover invalid input or errors from APIs
2. Add error handling around API calls
3. Capture more data from the Incident and Weather
3. Add side bar to display display more detailed data
3. Display Fire Department apparatus markers on the map
4. Add buttons to the map to show Fire Department apparatus at time of Dispatch and at time of Arrival
