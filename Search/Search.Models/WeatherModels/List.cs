using System.Text.Json.Serialization;

namespace Search.Models
{
    public partial class WeatherModels
    {
        public class List
        {
            public ulong Dt { get; set; }

            public Main? Main { get; set; }

            public Weather[] Weather { get; set; } = Array.Empty<Weather>();

            public Clouds? Clouds { get; set; }

            public Wind? Wind { get; set; }

            public ushort Visibility { get; set; }
            
            public double Pop { get; set; }

            public Sys? Sys { get; set; }
            
            [JsonPropertyName("dt_txt")]
            public string? DtTxt { get; set; }
        }
    }
}
