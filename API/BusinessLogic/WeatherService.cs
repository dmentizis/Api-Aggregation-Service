using DMSubmission.Objects.DTOs;
using DMSubmission.Objects.Entities;
using DMSubmission.Services;
using System.Linq.Expressions;

namespace DMSubmission.BusinessLogic
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherApiService _weatherApiService;

        public WeatherService(IWeatherApiService weatherApiService)
        {
            _weatherApiService = weatherApiService;
        }
        /// <summary>
        /// Get the current weather of a city globally.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Current weather data of the input city.</returns>
        public async Task<GetCityCurrentWeatherControllerResponseDTO>FindCityCurrentWeatherAsync(GetCityCurrentWeatherControllerRequestDTO request)
        {
            WeatherServiceApiRequestDTO apiServiceRequest = new WeatherServiceApiRequestDTO()
            {
                CityName = request.CityName
            };
            WeatherServiceApiResponseDTO apiServiceResponse;
            try 
            {
                apiServiceResponse = await _weatherApiService.GetCurrentWeatherByCityNameAsync(apiServiceRequest);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (apiServiceResponse == null)
            {
                throw new Exception("Could not fetch data from API service");
            }

            CityWeather cityWeather;
            try
            {
                cityWeather = new CityWeather()
                {
                    CityName = apiServiceResponse.name,
                    WeatherDescription = $"{apiServiceResponse.weather.FirstOrDefault().main}, {apiServiceResponse.weather.FirstOrDefault().description}",
                    Temperature = apiServiceResponse.main.temp,
                    TemperatureFeels = apiServiceResponse.main.feels_like,
                    Humidity = apiServiceResponse.main.humidity,
                    WindSpeed = apiServiceResponse.wind.speed
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not convert API request data to City Weather data {ex.Message}");
            }

            if(cityWeather == null)
            {
                throw new Exception("City Weather data not found");
            }

            GetCityCurrentWeatherControllerResponseDTO response = new GetCityCurrentWeatherControllerResponseDTO()
            {
                CityWeather = cityWeather
            };

            return response;
        }
    }
}