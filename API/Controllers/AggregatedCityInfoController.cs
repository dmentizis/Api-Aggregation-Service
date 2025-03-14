using DMSubmission.BusinessLogic;
using DMSubmission.Objects.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DMSubmission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AggregatedCityInfoController : ControllerBase
    {
        private readonly ICityInfoService _cityInfoService;

        public AggregatedCityInfoController(ICityInfoService cityInfoService)
        {
            _cityInfoService = cityInfoService;
        }

        /// <summary>
        /// Api endpoint that gathers returns information about a specific city. The endpoint fetches data regarding the current weather of the
        /// specific city, related books and news articles. If the city's current weather is not found, the endpoint will not return realted books and
        /// articles. In contrast, if the endpoind does not find related news articles or books, the endpoint will fetch the rest of the data regardless.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(GetCityInfoControllerResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetCityInfo")]
        public async Task<IActionResult> GetCityInfoAsync([FromQuery] GetCityInfoControllerRequestDTO request)
        {
            try
            {
                var response = await _cityInfoService.FindCityAggregatedInfo(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
