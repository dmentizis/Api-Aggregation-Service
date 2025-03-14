using DMSubmission.Objects.DTOs;

namespace DMSubmission.BusinessLogic
{
    public interface INewsArticleService
    {
        Task<GetNewsArticlesControllerResponseDTO> FindNewsArticlesAsync(FindNewsControllerRequestDTO request);
    }
}
