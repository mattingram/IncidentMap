using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IncidentMap.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IConfiguration Configuration;
    private readonly string GoogleMapsApiKey = "";
    public string GoogleMapsApiUrl => $"https://maps.googleapis.com/maps/api/js?key={GoogleMapsApiKey}&callback=initMap";

    public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
    {
        _logger = logger;
        Configuration = configuration;
        GoogleMapsApiKey = Configuration["GoogleMapsApiKey"];
        
        if (string.IsNullOrEmpty(GoogleMapsApiKey))
        {
            throw new Exception("Google Maps API key is not configured. Please set the GoogleMapsApiKey configuration key in the appsettings.json file or add as a command line argument.");
        }
    }

    public void OnGet()
    {
        
    }
}
