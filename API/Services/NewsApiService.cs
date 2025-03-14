using DMSubmission.Objects.DTOs;
using Microsoft.Extensions.Options;
using System.Text.Json;
using static DMSubmission.Objects.DTOs.NewsApiServiceResponseDTO;

namespace DMSubmission.Services
{
    public class NewsApiService : INewsApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private const string _baseUrl = "https://newsapi.org/v2/";

        public NewsApiService(HttpClient httpClient, IOptions<ExternalApiKeys> options)
        {
            _apiKey = options.Value.NewsApiKey;
            _httpClient = httpClient;
        }

        public async Task<NewsApiServiceResponseDTO> FindRelatedNewsAsync(NewsApiServiceRequestDTO request)
        {
            if(string.IsNullOrWhiteSpace(_apiKey))
            {
                throw new Exception("Weather Service API Key is missing.");
            }

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKey);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "MyNewsClient/1.0");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


            var url = $"{_baseUrl}everything?q={request.q}";

            if(request.language != null)
            {
                url += $"&language={request.language}";
            }

            if(request.sortBy != null)
            {
                url += $"&sortBy={request.sortBy}";
            }


            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {

                throw new Exception($"News Service API call failed: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();

            NewsApiServiceResponseDTO? serviceResponse = new NewsApiServiceResponseDTO();

            if (content != null)
            {
                serviceResponse = JsonSerializer.Deserialize<NewsApiServiceResponseDTO>(content);
            }

            if (serviceResponse != null)
            {
                return serviceResponse;
            }
            else
            {
                throw new Exception("News API Service could not parse External API response");
            }

        }
    }
}
