using DMSubmission.Objects.DTOs;

namespace DMSubmission.BusinessLogic
{
    public interface IWeatherService
    {
        Task<GetCityCurrentWeatherControllerResponseDTO>FindCityCurrentWeatherAsync(GetCityCurrentWeatherControllerRequestDTO request);
    }
}
