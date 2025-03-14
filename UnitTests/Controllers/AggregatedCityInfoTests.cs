using System.Net;

namespace UnitTests.Controllers
{
    public class AggregatedCityInfoTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public AggregatedCityInfoTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        #region Endpoint Validation
        [Fact]
        public async Task AggregatedCityInfoSmokeTest()
        {
            var requestUri = "https://localhost:44388/api/AggregatedCityInfo/GetCityInfo?CityName=New%20York&SortArticlesOrder=relevancy&ArticleLanguage=en";

            var response = await _client.GetAsync(requestUri);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        #endregion
        #region Invalid Inputs
        #endregion
        #region Security
        #endregion
        #region Performance
        #endregion

    }
}
