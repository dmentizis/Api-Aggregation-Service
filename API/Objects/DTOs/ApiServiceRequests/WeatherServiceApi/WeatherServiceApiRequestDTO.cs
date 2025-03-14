namespace DMSubmission.Objects.DTOs
{
    public class WeatherServiceApiRequestDTO
    {
        public string CityName { get; set; }
        public string? Mode { get; set; }
        public string? Units { get; set; }
        public string? Language { get; set; }

    }
}
