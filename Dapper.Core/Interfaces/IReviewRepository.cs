using Dapper.Core.Entities;

namespace Dapper.Core.Interfaces;

public interface IReviewRepository
{
    IEnumerable<Review> GetReviewsByMovieId(int movieId);
    int CreateReview(Review review);
    bool MovieExists(int movieId);
    bool ReviewExists(int reviewId);
    int DeleteReview(int id);
    bool UpdateReview(Review review);
    
}
    