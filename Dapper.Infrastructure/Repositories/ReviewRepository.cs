using System.Data;
using Dapper.Core.Entities;
using Dapper.Core.Interfaces;
using Dapper.Infrastructure.Data;

namespace Dapper.Infrastructure.Repositories;

public class ReviewRepository: IReviewRepository
{
    private readonly IDbConnection _dbConnection;
    
    public ReviewRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    // Return review(s) via MovieId
    public IEnumerable<Review> GetReviewsByMovieId(int movieId)
    {
        return _dbConnection.Query<Review>("SELECT Id, MovieId, UserId, Rating, Comment, CreatedAt " +
                                           "FROM Reviews WHERE MovieId = @MovieId", new  { MovieId = movieId });
    }
    // This is to check if MovieId does exist before Create operation
    public bool MovieExists(int movieId)
    {
        var count = _dbConnection.QuerySingle<int>(
            "SELECT COUNT(1) FROM Movies WHERE Id = @Id", new { Id = movieId });
        return count > 0;
    }
    
    // Create a review via user input
    public int CreateReview(Review review)
    {
        return _dbConnection.Execute(
            "INSERT INTO Reviews (MovieId, UserId, Rating, Comment, CreatedAt) " +
            "VALUES (@MovieId, @UserId, @Rating, @Comment, @CreatedAt)",
            review);
    }
    
    // This is to check that if ReviewID does exist before Delete operation
    public bool ReviewExists(int reviewId)
    {
        var count = _dbConnection.QuerySingle<int>(
            "SELECT COUNT(1) FROM Reviews WHERE Id = @ReviewId", new { ReviewId = reviewId });
        return count > 0;
    }
    public int DeleteReview(int id)
    {
        return _dbConnection.Execute(
            "DELETE FROM Reviews WHERE Id = @id", new { Id = id });
    }

    public int UpdateReview(Review review)
    {
        return _dbConnection.Execute(
            "UPDATE Reviews SET Comment = @Comment, CreatedAt=@CreatedAt WHERE Id = @Id", review);
    }

}