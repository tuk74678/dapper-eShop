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
        Console.WriteLine("Please enter the movie ID: ");
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

    public void run()
    {
        PrintReviewsByMovieId();
    }
}