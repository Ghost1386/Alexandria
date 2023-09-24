using Alexandria.Common.DTOs;
using Alexandria.Common.DTOs.LectureDTOs;
using Alexandria.Models.Models;

namespace Alexandria.BusinessLogic.Interfaces;

public interface IReviewService
{
    void CreateReview(Identifier identifier, RequestLectureGetDto requestLectureGetDto);

    Task<List<Review>> GetReview(Identifier identifier);
}