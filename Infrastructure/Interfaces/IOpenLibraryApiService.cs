using Infrastructure.Objects.DTOs.Requests;
using Infrastructure.Objects.DTOs.Responses;

namespace Infrastructure.Interfaces
{
    public interface IOpenLibraryApiService
    {
        Task<OpenLibraryApiResponseDTO> GetBooksByKeywordAsync(OpenLibraryApiRequestDTO request);
    }
}
