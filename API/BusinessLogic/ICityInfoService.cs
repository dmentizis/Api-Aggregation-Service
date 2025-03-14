using DMSubmission.Objects.DTOs;

namespace DMSubmission.BusinessLogic
{
    public interface ICityInfoService
    {
        Task<GetCityInfoControllerResponseDTO> FindCityAggregatedInfo(GetCityInfoControllerRequestDTO request);
    }
}
