namespace Search.Services
{
    public class NewsServiceApiSettingsService : INewsApiSettingsService
    {
        public Uri BaseUrl => new(Environment.GetEnvironmentVariable("NewsApiSettingsBaseUrl")!);
        
        public string ApiKey => Environment.GetEnvironmentVariable("NewsApiSettingsApiKey")!;
        
        public IDictionary<string, string> DefaultHeaders => new Dictionary<string, string>()
        {
            { Environment.GetEnvironmentVariable("NewsApiSettingsDefaultHeaderUserAgentKey")!, Environment.GetEnvironmentVariable("NewsApiSettingsDefaultHeaderUserAgentValue")! }
        };
    }
}
