using Search.Models;

namespace Search.Services
{
    public interface IWeatherService
    {
        Task<WeatherModels.CurrentWeatherCityStateCountry> GetCurrentWeatherByCityStateCountryAsync(HttpClient httpClient, string apiKey, string cityName, string stateCode, string countryCode);
        
        Task<WeatherModels.CurrentWeatherLatLon> GetCurrentWeatherByLatLonAsync(HttpClient httpClient, string apiKey, double lat, double lon);
        
        Task<WeatherModels.ForecastZipCodeCountryCode> GetForecastByZipCodeCountryCodeAsync(HttpClient httpClient, string apiKey, string zipCode, string countryCode);
    }
}
