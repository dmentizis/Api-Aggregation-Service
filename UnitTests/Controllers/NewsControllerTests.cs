using System.Net;

namespace UnitTests.Controllers
{
    public class NewsControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public NewsControllerTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        public async Task NewsControllerSmokeTest()
        {
            var requestUri = "https://localhost:44388/api/News/FindNewsArticles?SearchText=Bitcoin&SortBy=relevancy&Language=en";

            var response = await _client.GetAsync(requestUri);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
