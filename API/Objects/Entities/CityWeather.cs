namespace DMSubmission.Objects.Entities
{
    public class CityWeather
    {
        public string? CityName { get; set; }
        public string? WeatherDescription { get; set; }
        public double? Temperature { get; set; }
        public double? TemperatureFeels { get; set; }
        public int? Humidity { get; set; }
        public double? WindSpeed { get; set; }
    }
}
