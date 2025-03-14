using DMSubmission.Objects.DTOs;

namespace DMSubmission.Services
{
    public interface IWeatherApiService
    {
        Task<WeatherServiceApiResponseDTO> GetCurrentWeatherByCityNameAsync(WeatherServiceApiRequestDTO request);
    }
}
