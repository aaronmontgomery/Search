using System.Net.Http.Json;
using Search.Models;

namespace Search.Services
{
    public class WeatherService : IWeatherService
    {
        [Obsolete]
        public async Task<WeatherModels.CurrentWeatherCityStateCountry> GetCurrentWeatherByCityStateCountryAsync(HttpClient httpClient, string apiKey, string cityName, string stateCode, string countryCode)
        {
            WeatherModels.CurrentWeatherCityStateCountry? currentWeatherCityStateCountry;
            
            currentWeatherCityStateCountry = await httpClient.GetFromJsonAsync<WeatherModels.CurrentWeatherCityStateCountry>($"/data/2.5/weather?q={cityName},{stateCode},{countryCode}&appid={apiKey}");
            return currentWeatherCityStateCountry!;
        }
        
        public async Task<WeatherModels.CurrentWeatherLatLon> GetCurrentWeatherByLatLonAsync(HttpClient httpClient, string apiKey, double lat, double lon)
        {
            WeatherModels.CurrentWeatherLatLon? currentWeatherLatLon;
            
            currentWeatherLatLon = await httpClient.GetFromJsonAsync<WeatherModels.CurrentWeatherLatLon>($"/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}");
            return currentWeatherLatLon!;
        }

        public async Task<WeatherModels.ForecastZipCodeCountryCode> GetForecastByZipCodeCountryCodeAsync(HttpClient httpClient, string apiKey, string zipCode, string countryCode)
        {
            WeatherModels.ForecastZipCodeCountryCode? forecastZipCodeCountryCode;
            
            forecastZipCodeCountryCode = await httpClient.GetFromJsonAsync<WeatherModels.ForecastZipCodeCountryCode>($"/data/2.5/forecast?zip={zipCode},{countryCode}&appid={apiKey}");
            return forecastZipCodeCountryCode!;
        }
    }
}
