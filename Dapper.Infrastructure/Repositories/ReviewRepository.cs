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

    // public int Insert(Review obj)
    // {
    //     IDbConnection conn = _dbConnection.GetConnection();
    //     return conn.Execute("INSERT INTO Reviews VALUES (@MovieId, @UserId, @Rating, @Comment, @CreatedAt)", obj);
    // }
    
    public IEnumerable<Review> GetReviewsByMovieId(int movieId)
    {
        return _dbConnection.Query<Review>("SELECT Id, MovieId, UserId, Rating, Comment, CreatedAt " +
                                           "FROM Reviews WHERE MovieId = @MovieId", new  { MovieId = movieId });
    }

    public Review GetReviewById(int id)
    {
        throw new NotImplementedException();
    }

    public int AddReview(Review review)
    {
        throw new NotImplementedException();
    }

    public bool UpdateReview(Review review)
    {
        throw new NotImplementedException();
    }

    public bool DeleteReview(int id)
    {
        throw new NotImplementedException();
    }
}