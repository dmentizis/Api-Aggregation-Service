using DMSubmission.BusinessLogic;
using DMSubmission.Objects.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DMSubmission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<WeatherController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        /// <summary>
        /// Find information about books related to a specific keyword.
        /// </summary>
        /// <param name="request">Test</param>
        /// <returns>Test</returns>
        [ProducesResponseType(typeof(GetBooksByKeywordControllerResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("FindBooks")]
        public async Task<IActionResult> GetBooksByKeyword([FromQuery] FindBooksControllerRequestDTO request)
        {
            try
            {
                var response = await _bookService.FindBooksAsync(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
