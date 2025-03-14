namespace DMSubmission.Objects.DTOs
{
    public class OpenLibraryApiResponseDTO
    {
        public int numFound { get; set; }
        public int start { get; set; }
        public bool numFoundExact { get; set; }
        public int num_found { get; set; }
        public string documentation_url { get; set; }
        public string q { get; set; }
        public object offset { get; set; }
        public List<Doc> docs { get; set; }

        public class Doc
        {
            public List<string> author_key { get; set; }
            public List<string> author_name { get; set; }
            public int edition_count { get; set; }
            public int first_publish_year { get; set; }
            public bool has_fulltext { get; set; }
            public string key { get; set; }
            public List<string> language { get; set; }
            public bool public_scan_b { get; set; }
            public string title { get; set; }
            public string cover_edition_key { get; set; }
            public int? cover_i { get; set; }
            public List<string> ia { get; set; }
            public string subtitle { get; set; }
        }

    }
}
