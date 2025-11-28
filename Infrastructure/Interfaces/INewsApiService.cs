using Infrastructure.Objects.DTOs.Requests;
using Infrastructure.Objects.DTOs.Responses;

namespace Infrastructure.Interfaces
{
    public interface INewsApiService
    {
        Task<NewsApiServiceResponseDTO> FindRelatedNewsAsync(NewsApiServiceRequestDTO request);
    }
}
