using System.Net;

namespace UnitTests.Controllers
{
    public class WeatherControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public WeatherControllerTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task WeatherControllerSmokeTest()
        {
            // Arrange
            var requestUri = "/api/Weather/CityWeather?CityName=London";

            // Act
            var response = await _client.GetAsync(requestUri);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetCityWeatherUsingUsingInvalidCityAsync()
        {
            // Arrange
            var requestUri = "/api/Weather/CityWeather?CityName=ohfgoidhoi";

            // Act
            var response = await _client.GetAsync(requestUri);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetCityWeatherUsingUsingNullCityAsync()
        {
            // Arrange
            var requestUri = "/api/Weather/CityWeather?CityName=";

            // Act
            var response = await _client.GetAsync(requestUri);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
