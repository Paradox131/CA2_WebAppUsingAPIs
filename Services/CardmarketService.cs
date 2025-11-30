namespace CA2_WebAppUsingAPIs.Services
{
    using Newtonsoft.Json;
    using System.Net.Http.Headers;
    using System.Net.Http.Json;
    using System.Text.Json.Serialization;

    public class CardmarketService
    {
        private readonly HttpClient _httpClient;
        private readonly string _appToken = "YOUR_APP_TOKEN";
        private readonly string _appSecret = "YOUR_APP_SECRET";
        private readonly string _accessToken = "YOUR_ACCESS_TOKEN";
        private readonly string _username = "YOUR_USERNAME";

        public CardmarketService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Cardmarket");
        }

        // Example: Get Yu-Gi-Oh products by name
        public async Task<List<CardProduct>> SearchYuGiOhCardsAsync(string cardName)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"products?game=YuGiOh&search={cardName}");

            // Add Cardmarket authentication headers
            request.Headers.Add("Authorization", $"Bearer {_accessToken}");
            request.Headers.Add("X-Private-AppToken", _appToken);
            request.Headers.Add("X-Private-AppSecret", _appSecret);
            request.Headers.Add("X-Private-Username", _username);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CardmarketSearchResponse>(json);

            return result.Products;
        }
    }

    public class CardProduct
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public string Expansion { get; set; }
        public string Rarity { get; set; }
        public decimal Price { get; set; }
    }

    public class CardmarketSearchResponse
    {
        [JsonProperty("product")]
        public List<CardProduct> Products { get; set; } = new();
    }
}
