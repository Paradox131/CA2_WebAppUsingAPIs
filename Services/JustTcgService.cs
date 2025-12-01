namespace CA2_WebAppUsingAPIs.Services
{
    using CA2_WebAppUsingAPIs.Models;
    //using CA2_WebAppUsingAPIs.Models.YourApp.Models;
    using Microsoft.Extensions.Options;

    public class JustTcgService
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;

        public JustTcgService(IHttpClientFactory httpFactory, IOptions<JustTcgSettings> options)
        {
            _http = httpFactory.CreateClient("JustTCG");
            _apiKey = options.Value.ApiKey;
        }

        public async Task<Card[]> SearchCardsAsync(string query)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"cards?q={Uri.EscapeDataString(query)}");
            request.Headers.Add("x-api-key", _apiKey);

            var response = await _http.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<JustTcgResponse>();
            return result?.data;
        }
    }
}
