using DMSubmission.Objects.Entities;
using System.ComponentModel;

namespace DMSubmission.Objects.DTOs
{
    /// <summary>
    /// Weather controller GetCityCurrentWeather Endpoint request response
    /// </summary>
    public class GetCityCurrentWeatherControllerResponseDTO
    {
        [Description("Weather details of a City")]
        public CityWeather? CityWeather { get; set; }
    }
}
