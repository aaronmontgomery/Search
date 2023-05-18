namespace Search.Models
{
    public partial class WeatherModels
    {
        public class ForecastZipCodeCountryCode
        {
            public string? Cod { get; set; }

            public ulong Message { get; set; }

            public ulong Cnt { get; set; }

            public List[] List { get; set; } = Array.Empty<List>();

            public City? City { get; set; }
        }
    }
}
