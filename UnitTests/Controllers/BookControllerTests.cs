using System.Net;

namespace UnitTests.Controllers
{
    public class BookControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public BookControllerTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        public async Task BookControllerSmokeTest()
        {
            var requestUri = "https://localhost:44388/api/Book/FindBooks?SearchText=Cooking";

            var response = await _client.GetAsync(requestUri);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
