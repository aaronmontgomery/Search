namespace Search.Models
{
    public partial class NewsModels
    {
        public class NewsData
        {
            public string? Status { get; set; }
            
            public ulong TotalResults { get; set; }
            
            public Articles[] Articles { get; set; } = Array.Empty<Articles>();
        }
    }
}
