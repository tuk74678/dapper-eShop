using Dapper.Core.Interfaces;

namespace Dapper.eShop.UI;

public class ReviewService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }
   
}