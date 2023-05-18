using System.Text.Json.Serialization;

namespace Search.Models
{
    public partial class WeatherModels
    {
        public class Main
        {
            public double Temp { get; set; }
            
            [JsonPropertyName("feels_like")]
            public double FeelsLike { get; set; }
            
            [JsonPropertyName("temp_min")]
            public double TempMin { get; set; }
            
            [JsonPropertyName("temp_max")]
            public double TempMax { get; set; }
            
            public ulong Pressure { get; set; }
            
            public byte Humidity { get; set; }
        }
    }
}
