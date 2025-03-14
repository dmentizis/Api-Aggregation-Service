using DMSubmission.Objects.Entities;
using System.ComponentModel;

namespace DMSubmission.Objects.DTOs
{
    /// <summary>
    /// Books controller GetBooksByKeyword endpoint request response.
    /// </summary>
    public class GetBooksByKeywordControllerResponseDTO
    {
        [Description("List of Books' Information")]
        public IEnumerable<Book>? Booklist { get; set; }
    }
}
