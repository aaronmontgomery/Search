using System.Net.Http.Json;
using Search.Models;

namespace Search.Services
{
    public class NewsService : INewsService
    {
        public async Task<NewsModels.NewsData> GetTopHeadlinesAsync(HttpClient httpClient, string apiKey, string country)
        {
            NewsModels.NewsData? newsData;
            
            newsData = await httpClient.GetFromJsonAsync<NewsModels.NewsData>($"/v2/top-headlines?country={country}&apiKey={apiKey}");
            return newsData!;
        }
    }
}
