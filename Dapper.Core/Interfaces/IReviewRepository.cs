using Dapper.Core.Entities;

namespace Dapper.Core.Interfaces;

public interface IReviewRepository
{
    IEnumerable<Review> GetReviewsByMovieId(int movieId);
    Review GetReviewById(int id);
    int AddReview(Review review);
    bool UpdateReview(Review review);
    bool DeleteReview(int id);
}
    