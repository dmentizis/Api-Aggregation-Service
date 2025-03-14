namespace DMSubmission.Objects.Entities
{
    public class Book
    {
        public List<string>? AuthorName { get; set; }
        public List<string>? Language { get; set; }
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public int? FirstPublishYear { get; set; }
    }
}
