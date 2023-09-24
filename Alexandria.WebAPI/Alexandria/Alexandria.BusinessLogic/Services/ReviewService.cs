using Alexandria.BusinessLogic.Interfaces;
using Alexandria.Common.DTOs;
using Alexandria.Common.DTOs.LectureDTOs;
using Alexandria.DAL.Interfaces;
using Alexandria.Models.Models;

namespace Alexandria.BusinessLogic.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public void CreateReview(Identifier identifier, RequestLectureGetDto requestLectureGetDto)
    {
        var review = new Review
        {
            UserId = identifier.Id,
            CombinePlacement = requestLectureGetDto.CombinePlacement
        };
        
        _reviewRepository.CreateReview(review);
    }

    public async Task<List<Review>> GetReview(Identifier identifier)
    {
        var reviews = await _reviewRepository.GetUserReview(identifier);

        return reviews;
    }
}