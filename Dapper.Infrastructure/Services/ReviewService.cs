using Dapper.Core.Entities;
using Dapper.Core.Interfaces;

namespace Dapper.eShop.UI;

public class ReviewService
{
    private readonly IReviewRepository _reviewRepository;
    
    public ReviewService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public void PrintReviewsByMovieId()
    {
        Console.WriteLine("Please enter the movie ID:\n");
        int id = int.Parse(Console.ReadLine());
        IEnumerable<Review> reviews = _reviewRepository.GetReviewsByMovieId(id);
        if (!reviews.Any())
        {
            Console.WriteLine("No reviews found for this movie.");
            return;
        }

        foreach (var review in reviews)
        {
            Console.WriteLine($"Review ID: {review.Id}");
            Console.WriteLine($"User ID: {review.UserId}");
            Console.WriteLine($"Rating: {review.Rating}");
            Console.WriteLine($"Comment: {review.Comment}");
            Console.WriteLine($"Created At: {review.CreatedAt}");
            Console.WriteLine("------------------------------");
        }
    }

    public void AddReview()
    {
        Console.WriteLine("Please enter the MovieId: ");
        // Check MovieId does exist in the Movies table
        int movieId = int.Parse(Console.ReadLine());
        if (!_reviewRepository.MovieExists(movieId))
        {
            Console.WriteLine("Error: Movie with this ID does not exist.");
            return;
        }
        var review = new Review();
        
        review.MovieId = movieId;
        Console.WriteLine("Please enter the User Id: ");
        review.UserId = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the Rating: ");
        review.Rating = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the Comment: ");
        review.Comment = Console.ReadLine();
        review.CreatedAt = DateTime.UtcNow;
        _reviewRepository.CreateReview(review);
    }
    public void run()
    {
        //PrintReviewsByMovieId();
        AddReview();
    }
}