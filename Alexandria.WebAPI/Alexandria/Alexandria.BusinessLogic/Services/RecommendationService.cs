using Alexandria.BusinessLogic.Interfaces;
using Alexandria.Common.DTOs;
using Alexandria.Common.DTOs.LectureDTOs;

namespace Alexandria.BusinessLogic.Services;

public class RecommendationService : IRecommendationService
{
    private readonly IReviewService _reviewService;
    private readonly ILectureService _lectureService;

    public RecommendationService(IReviewService reviewService, ILectureService lectureService)
    {
        _reviewService = reviewService;
        _lectureService = lectureService;
    }

    public async Task<List<ResponseLectureGetDto>> CreateAndGetRecommendation(Identifier identifier)
    {
        var reviews = await _reviewService.GetReview(identifier);

        var listCombinePlacement = new List<string?>();
        
        foreach (var review in reviews)
        {
            listCombinePlacement.Add(review.CombinePlacement?.
                Substring(0, review.CombinePlacement.LastIndexOf("///", 
                    StringComparison.CurrentCulture)));
        }

        var listRequestLectureGetDto = listCombinePlacement.Select(l => new RequestLectureGetDto
        {
            CombinePlacement = l
        }).ToList();

        var responseLectureGetDtos = _lectureService.GetRecommendationsLecture(listRequestLectureGetDto);
        
        return responseLectureGetDtos;
    }
}