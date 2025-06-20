using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
    private readonly HttpClient _http;

    public NewsController(IHttpClientFactory factory)
    {
        _http = factory.CreateClient();

        // رأس التعريف (مطلوب)
        _http.DefaultRequestHeaders.UserAgent.ParseAdd(
            "SoccerIQ/1.0 (+https://your-domain.com)");

        // مفتاح NewsAPI
        _http.DefaultRequestHeaders.Add(
            "X-Api-Key",
            Environment.GetEnvironmentVariable("NEWS_API_KEY")
            ?? "7f6e437c2b964dfe99fab9bd1400d03e");
    }

    [HttpGet]
    public async Task<IActionResult> GetLiveNews(
        string country = "gb",        // إنجلترا
        string category = "sports")   // رياضة
    {
        string url =
            $"https://newsapi.org/v2/top-headlines?country={country}&category={category}";

        var res = await _http.GetAsync(url);
        var body = await res.Content.ReadAsStringAsync();

        if (!res.IsSuccessStatusCode)
            return StatusCode((int)res.StatusCode, body);

        return Content(body, "application/json");
    }
}
