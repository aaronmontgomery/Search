namespace Search.Models
{
    public partial class WeatherModels
    {
        public class Weather
        {
            public ulong Id { get; set; }

            public string? Main { get; set; }

            public string? Description { get; set; }

            public string? Icon { get; set; }
        }
    }
}
