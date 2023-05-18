using Microsoft.AspNetCore.Mvc;
using Search.Services;

namespace Search.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IWeatherApiSettingsService _weatherApiSettingsService;
        private readonly IWeatherService _weatherService;
        
        public WeatherController(IHttpClientFactory httpClientFactory, IWeatherApiSettingsService weatherApiSettingsService, IWeatherService weatherService)
        {
            _weatherService = weatherService;
            _weatherApiSettingsService = weatherApiSettingsService;
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = weatherApiSettingsService.BaseUrl;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", weatherApiSettingsService.DefaultHeaders["User-Agent"]);
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentWeatherByLatLon(double lat, double lon)
        {
            IActionResult actionResult;
            
            try
            {
                actionResult = Ok(await _weatherService.GetCurrentWeatherByLatLonAsync(_httpClient, _weatherApiSettingsService.ApiKey, lat, lon));
            }

            catch
            {
                actionResult = BadRequest();
            }

            return actionResult;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetForecastByZipCodeCountryCode(string zipCode, string country)
        {
            IActionResult actionResult;
            
            try
            {
                actionResult = Ok(await _weatherService.GetForecastByZipCodeCountryCodeAsync(_httpClient, _weatherApiSettingsService.ApiKey, zipCode, country));
            }
            
            catch
            {
                actionResult = BadRequest();
            }
            
            return actionResult;
        }
    }
}
