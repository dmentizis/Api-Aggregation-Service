using DMSubmission.Objects.DTOs;

namespace DMSubmission.BusinessLogic
{
    public interface IBookService
    {
        Task<GetBooksByKeywordControllerResponseDTO> FindBooksAsync(FindBooksControllerRequestDTO request);
    }
}
