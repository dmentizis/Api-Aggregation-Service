using DMSubmission.Objects.Entities;
using System.ComponentModel;

namespace DMSubmission.Objects.DTOs
{
    /// <summary>
    /// News Controller GetNewsArticles Endpoint response.
    /// </summary>
    public class GetNewsArticlesControllerResponseDTO
    {
        [Description("List of News Articles")]
        public IEnumerable<NewsArticle>? NewsArticles { get; set; }
    }
}
