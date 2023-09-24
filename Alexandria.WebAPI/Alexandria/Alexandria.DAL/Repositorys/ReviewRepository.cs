using Alexandria.Common.DTOs;
using Alexandria.DAL.Interfaces;
using Alexandria.Models;
using Alexandria.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Alexandria.DAL.Repositorys;

public class ReviewRepository : IReviewRepository
{
    private readonly ApplicationContext _applicationContext;

    public ReviewRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async void CreateReview(Review review)
    {
        await _applicationContext.Reviews.AddAsync(review);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task<List<Review>> GetUserReview(Identifier identifier)
    {
        var reviews = await _applicationContext.Reviews.
            Where(r => r.UserId == identifier.Id).ToListAsync();

        return reviews;
    }
}