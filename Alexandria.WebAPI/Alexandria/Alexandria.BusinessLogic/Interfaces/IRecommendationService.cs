using Alexandria.Common.DTOs;
using Alexandria.Common.DTOs.LectureDTOs;

namespace Alexandria.BusinessLogic.Interfaces;

public interface IRecommendationService
{
    Task<List<ResponseLectureGetDto>> CreateAndGetRecommendation(Identifier identifier);
}