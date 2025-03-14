using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DMSubmission.Objects.DTOs
{
    /// <summary>
    /// Book Controller GetBooksByKeyword endpoint request parameters.
    /// </summary>
    public class FindBooksControllerRequestDTO
    {
        [DefaultValue("Cooking")]
        [Description("Keyword to find books related to")]
        [Required]
        public string SearchText { get; set; }
    }
}
