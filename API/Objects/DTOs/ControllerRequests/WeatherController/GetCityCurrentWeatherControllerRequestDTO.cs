using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DMSubmission.Objects.DTOs
{
    /// <summary>
    /// Weather Controller GetCityCurrentWeather endpoint parameters.
    /// </summary>
    public class GetCityCurrentWeatherControllerRequestDTO
    {
        [Required]
        [DefaultValue("London")]
        [Description("The name of the city to get the current weather for")]
        public string CityName { get; set; }
    }
}
