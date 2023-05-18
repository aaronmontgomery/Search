namespace Search.Services
{
    public class WeatherServiceApiSettingsService : IWeatherApiSettingsService
    {
        public Uri BaseUrl => new(Environment.GetEnvironmentVariable("WeatherApiSettingsBaseUrl")!);
        
        public string ApiKey => Environment.GetEnvironmentVariable("WeatherApiSettingsApiKey")!;
        
        public IDictionary<string, string> DefaultHeaders => new Dictionary<string, string>()
        {
            { Environment.GetEnvironmentVariable("WeatherApiSettingsDefaultHeaderUserAgentKey")!, Environment.GetEnvironmentVariable("WeatherApiSettingsDefaultHeaderUserAgentValue")! }
        };
    }
}
