using Microsoft.AspNetCore.Mvc;
using Search.Services;

namespace Search.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly INewsApiSettingsService _newsApiSettingsService;
        private readonly INewsService _newsService;
        
        public NewsController(IHttpClientFactory httpClientFactory, INewsApiSettingsService newsApiSettingsService, INewsService newsService)
        {
            _newsService = newsService;
            _newsApiSettingsService = newsApiSettingsService;
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = newsApiSettingsService.BaseUrl;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", newsApiSettingsService.DefaultHeaders["User-Agent"]);
        }

        [HttpGet]
        public async Task<IActionResult> GetTopHeadlines(string country)
        {
            IActionResult actionResult;

            try
            {
                actionResult = Ok(await _newsService.GetTopHeadlinesAsync(_httpClient, _newsApiSettingsService.ApiKey, country));
            }
            
            catch
            {
                actionResult = BadRequest();
            }

            return actionResult;
        }
    }
}
