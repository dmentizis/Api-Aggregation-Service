using DMSubmission.BusinessLogic;
using DMSubmission.Objects.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DMSubmission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherController(ILogger<WeatherController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        /// <summary>
        /// Get the current weather of the city that you input.
        /// </summary>
        /// <param name="request">The Name of the City</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(GetCityCurrentWeatherControllerResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("CityWeather")]
        public async Task<IActionResult> GetCityCurrentWeather([FromQuery] GetCityCurrentWeatherControllerRequestDTO request)
        {
            try
            {
                var currentCityWeather = await _weatherService.FindCityCurrentWeatherAsync(request);
                return Ok(currentCityWeather);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
