using Search.Models;

namespace Search.Services
{
    public interface INewsService
    {
        Task<NewsModels.NewsData> GetTopHeadlinesAsync(HttpClient httpClient, string apiKey, string country);
    }
}
