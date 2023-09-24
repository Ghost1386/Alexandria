using Alexandria.BusinessLogic.Interfaces;
using Alexandria.BusinessLogic.Services;
using Alexandria.DAL.Interfaces;
using Alexandria.DAL.Repositorys;

namespace Alexandria.WebAPI.Middlewares;

public static class DependenciesMiddleware
{
    public static void AddIService(this IServiceCollection services)
    {
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IBraintreeService, BraintreeService>();
        services.AddTransient<IHashService, HashService>();
        services.AddTransient<ILectureService, LectureService>();
        services.AddTransient<IModificationService, ModificationService>();
        services.AddTransient<IPaymentService, PaymentService>();
        services.AddTransient<IRecommendationService, RecommendationService>();
        services.AddTransient<IReviewService, ReviewService>();
        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IUserService, UserService>();
    }
    
    public static void AddIRepository(this IServiceCollection services)
    {
        services.AddTransient<ILectureRepository, LectureRepository>();
        services.AddTransient<IModificationRepository, ModificationRepository>();
        services.AddTransient<IPaymentRepository, PaymentRepository>();
        services.AddTransient<IReviewRepository, ReviewRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
    }
}