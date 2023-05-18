namespace Search.Models
{
    public partial class WeatherModels
    {
        public class City
        {
            public uint Id { get; set; }

            public string? Name { get; set; }

            public Coord? Coord { get; set; }

            public string? Country { get; set; }

            public ulong Population { get; set; }

            public long Timezone { get; set; }

            public ulong Sunrise { get; set; }

            public ulong Sunset { get; set; }
        }
    }
}
