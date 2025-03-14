using DMSubmission.Objects.DTOs;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace DMSubmission.Services
{
    public class WeatherApiService : IWeatherApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private const string _baseUrl = "https://api.openweathermap.org/data/2.5/";

        public WeatherApiService(HttpClient httpClient, IOptions<ExternalApiKeys> options)
        {
            _apiKey = options.Value.WeatherApiKey;
            _httpClient = httpClient;
        }

        public async Task<WeatherServiceApiResponseDTO> GetCurrentWeatherByCityNameAsync(WeatherServiceApiRequestDTO requestData)
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new Exception("Weather Service API Key is missing.");
            }

            var url = $"{_baseUrl}weather?q={requestData.CityName}&appid={_apiKey}";
            if (!string.IsNullOrWhiteSpace(requestData.Units))
            {
                url += $"units={requestData.Units}";
            }
            if (!string.IsNullOrWhiteSpace(requestData.Mode))
            {
                url += $"mode={requestData.Mode}";
            }
            if (!string.IsNullOrWhiteSpace(requestData.Language))
            {
                url += $"lang={requestData.Mode}";
            }

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Weather API call failed: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();

            WeatherServiceApiResponseDTO? serviceResponse = new WeatherServiceApiResponseDTO();

            if (content != null)
            {
                serviceResponse = JsonSerializer.Deserialize<WeatherServiceApiResponseDTO>(content);
            }

            if (serviceResponse != null)
            {
                return serviceResponse;
            }
            else
            {
                throw new Exception("Weather API Service could not parse External API response");
            }
        }
    }
}
