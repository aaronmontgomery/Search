﻿namespace Search.Models
{
    public partial class NewsModels
    {
        public class Articles
        {
            public Source? Source { get; set; }

            public string? Author { get; set; }

            public string? Title { get; set; }

            public string? Description { get; set; }

            public string? Url { get; set; }

            public string? UrlToImage { get; set; }

            public DateTime? PublishedAt { get; set; }

            public string? Content { get; set; }
        }
    }
}
