namespace Infrastructure.Objects
{
    public class ExternalApiKeys
    {
        public required string NewsApiKey { get; set; }
        public required string WeatherApiKey { get; set; }
        public required string OpenLibraryKey { get; set; }
    }
}
