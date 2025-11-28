using Infrastructure.Objects.DTOs.Requests;
using Infrastructure.Objects.DTOs.Responses;

namespace Infrastructure.Interfaces
{
    public interface IWeatherApiService
    {
        Task<WeatherServiceApiResponseDTO> GetCurrentWeatherByCityNameAsync(WeatherServiceApiRequestDTO request);
    }
}
