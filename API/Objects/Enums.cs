using System.Runtime.Serialization;

namespace DMSubmission.Objects
{
    public enum LanguageCodes
    {
        [EnumMember(Value = "ar")]
        ar,

        [EnumMember(Value = "de")]
        de,

        [EnumMember(Value = "en")]
        en,

        [EnumMember(Value = "es")]
        es,

        [EnumMember(Value = "fr")]
        fr,

        [EnumMember(Value = "he")]
        he,

        [EnumMember(Value = "it")]
        it,

        [EnumMember(Value = "nl")]
        nl,

        [EnumMember(Value = "no")]
        no,

        [EnumMember(Value = "pt")]
        pt,

        [EnumMember(Value = "ru")]
        ru,

        [EnumMember(Value = "sv")]
        sv,

        [EnumMember(Value = "ud")]
        ud,

        [EnumMember(Value = "zh")]
        zh
    }
    public enum SortArticlesByOptions
    {
        [EnumMember(Value = "relevancy")]
        relevancy,

        [EnumMember(Value = "popularity")]
        popularity,

        [EnumMember(Value = "publishedAt")]
        publishedAt
    }
}
