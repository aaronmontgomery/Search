namespace Search.Services
{
    public interface IApiSettingsService
    {
        Uri BaseUrl { get; }

        string ApiKey { get; }
        
        IDictionary<string, string> DefaultHeaders { get; }
    }
}
