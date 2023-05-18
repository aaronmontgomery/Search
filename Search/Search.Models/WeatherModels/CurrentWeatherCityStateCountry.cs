namespace Search.Models
{
    public partial class WeatherModels
    {
        public class CurrentWeatherCityStateCountry
        {
            public Weather[] Weather { get; set; } = Array.Empty<Weather>();
            
            public Main? Main { get; set; }
        }
    }
}
