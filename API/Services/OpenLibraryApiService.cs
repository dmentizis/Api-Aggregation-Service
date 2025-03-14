using DMSubmission.Objects.DTOs;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace DMSubmission.Services
{
    public class OpenLibraryApiService : IOpenLibraryApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private const string _baseUrl = "https://openlibrary.org/";

        public OpenLibraryApiService(HttpClient httpClient, IOptions<ExternalApiKeys> options)
        {
            _apiKey = options.Value.OpenLibraryKey;
            _httpClient = httpClient;
        }

        public async Task<OpenLibraryApiResponseDTO> GetBooksByKeywordAsync(OpenLibraryApiRequestDTO request)
        {
            if(string.IsNullOrWhiteSpace(request.SearchText))
            {
                throw new Exception("Invalid Book Search Keyword.");
            }

            var url = $"{_baseUrl}search.json?q={request.SearchText}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Book Service API call failed: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();

            OpenLibraryApiResponseDTO? serviceResponse = new OpenLibraryApiResponseDTO();

            if (content != null)
            {
                serviceResponse = JsonSerializer.Deserialize<OpenLibraryApiResponseDTO>(content);
            }

            if (serviceResponse != null) 
            {
                return serviceResponse;
            }
            else
            {
                throw new Exception("Open Library API Service could not parse External API response");
            }                        
        }
    }
}
