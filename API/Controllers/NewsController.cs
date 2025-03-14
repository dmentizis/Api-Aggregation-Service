using DMSubmission.BusinessLogic;
using DMSubmission.Objects.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DMSubmission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly ILogger<NewsController> _logger;
        private readonly INewsArticleService _newsArticleService;

        public NewsController(ILogger<NewsController> logger, INewsArticleService newsService)
        {
            _logger = logger;
            _newsArticleService = newsService;
        }

        /// <summary>
        /// Find news related to a keyword of your choice
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(GetNewsArticlesControllerResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("FindNewsArticles")]
        public async Task<IActionResult> GetNewsArticles([FromQuery] FindNewsControllerRequestDTO request)
        {
            try
            {
                var newsData = await _newsArticleService.FindNewsArticlesAsync(request);
                return Ok(newsData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
