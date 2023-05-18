namespace Search.Models
{
    public partial class WeatherModels
    {
        public class CurrentWeatherLatLon
        {
            public Coord? Coord { get; set; }

            public Weather[] Weather { get; set; } = Array.Empty<Weather>();

            public string? Base { get; set; }

            public Main? Main { get; set; }

            public ushort Visibility { get; set; }
            
            public Wind? Wind { get; set; }
            
            public Clouds? Clouds { get; set; }
            
            public ulong Dt { get; set; }
            
            public Sys? Sys { get; set; }

            public long Timezone { get; set; }

            public ulong Id { get; set; }

            public string? Name { get; set; }

            public ulong Cod { get; set; }
        }
    }
}
