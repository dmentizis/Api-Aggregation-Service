using DMSubmission.Objects.DTOs;

namespace DMSubmission.Services
{
    public interface INewsApiService
    {
        Task<NewsApiServiceResponseDTO> FindRelatedNewsAsync(NewsApiServiceRequestDTO request);
    }
}
