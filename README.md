# Incident Map

.NET web app that displays Fire Department incident data, enriches with weather data from https://dev.meteostat.net/ and displays incident data using Google Maps.

## Steps to Run

1. Ensure you have [.NET 6](https://dotnet.microsoft.com/en-us/download) installed
1. Configure the Google Maps Javascript API Key
    1. To get a Google Maps Javascript API Key, follow instructions here: https://developers.google.com/maps/documentation/javascript/cloud-setup
    1. Set the API key in appsettings.json or pass as an environment variable in `dotnet run --GoogleMapsApiKey=`
1. Configure Weather API Key
1. `dotnet run`
