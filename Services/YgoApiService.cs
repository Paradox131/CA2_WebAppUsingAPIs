namespace CA2_WebAppUsingAPIs.Services
{
    using System.Net.Http.Json;
    using static CA2_WebAppUsingAPIs.Models.YgoCard;

    public class YgoApiService
    {
        private readonly HttpClient _http;

        public YgoApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<CardInfo?> SearchCardByNameAsync(string name)
        {
            var url = $"api/v7/cardinfo.php?name={Uri.EscapeDataString(name)}";

            var result = await _http.GetFromJsonAsync<CardInfoResponse>(url);

            return result?.data?.FirstOrDefault();
        }
    }

}
