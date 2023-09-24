using Alexandria.Common.DTOs;
using Alexandria.Models.Models;

namespace Alexandria.DAL.Interfaces;

public interface IReviewRepository
{
    void CreateReview(Review review);

    Task<List<Review>> GetUserReview(Identifier identifier);
}