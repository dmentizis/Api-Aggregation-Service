using DMSubmission.Objects.Entities;
using System.ComponentModel;

namespace DMSubmission.Objects.DTOs
{
    /// <summary>
    /// AggregatedCityInfoController
    /// Information collection about a city including it's current weather, some articles and related books to the city.
    /// </summary>
    public class GetCityInfoControllerResponseDTO
    {
        [Description("The weather if the city at the time of the request")]
        public CityWeather CurrentWeather { get; set; }
        [Description("News articles related to the city")]
        public List<NewsArticle> RelatedArtices {  get; set; }
        [Description("Books related to the city")]
        public List<Book> RelatedBooks { get; set; }
    }
}
