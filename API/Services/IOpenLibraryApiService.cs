using DMSubmission.Objects.DTOs;

namespace DMSubmission.Services
{
    public interface IOpenLibraryApiService
    {
        Task<OpenLibraryApiResponseDTO> GetBooksByKeywordAsync(OpenLibraryApiRequestDTO request);
    }
}
