namespace DMSubmission.Objects.DTOs
{
    public class NewsApiServiceRequestDTO
    {
        public string? apiKey{ get; set; }
        public string q { get; set; }
        public string? searchIn { get; set; }
        public List<Source>? sources { get; set; }
        public string? domain { get; set; }
        public List<String>? excludeDomains { get; set; }
        public string? from { get; set; }
        public string? to { get; set; }
        public string? language { get; set; }
        public string? sortBy { get; set; }

        public class Source
        {
            public string? id { get; set; }
            public string? name { get; set; }
        }
    }
}
