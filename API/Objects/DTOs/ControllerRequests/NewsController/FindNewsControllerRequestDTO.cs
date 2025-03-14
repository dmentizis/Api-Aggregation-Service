using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DMSubmission.Objects.DTOs
{
    /// <summary>
    /// News Controller GetNewsArticles Endpoint request parameters.
    /// </summary>
    public class FindNewsControllerRequestDTO
    {
        [Required]
        [DefaultValue("Bitcoin")]
        [Description("Keyword to find news related to")]
        public string SearchText { get; set; }
        [DefaultValue("relevancy")]
        [Description("The order to sort the articles in. Possible options: relevancy, popularity, publishedAt. \r\n" +
            "relevancy = articles more closely related to SearchText come first.\r\n" +
            "popularity = articles from popular sources and publishers come first.\r\n" +
            "publishedAt = newest articles come first.")]
        [EnumDataType(typeof(SortArticlesByOptions))]
        public string? SortBy { get; set; }

        [DefaultValue("en")]
        [Description("Article language code, ISO 639-1, possible options: ar, de, en, es, fr, he, it, nl, no, pt, ru, sv, ud, zh")]
        [EnumDataType(typeof(LanguageCodes))]
        public string? Language { get; set; }
    }
}
