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

    public void printReviewsByMovieId()
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

    public void addReview()
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

    public void deleteReview()
    {
        Console.WriteLine("Please enter the ReviewId: ");
        // Check if the ReviewId does exist in the Reviews table
        int reviewId = int.Parse(Console.ReadLine());
        if (!_reviewRepository.ReviewExists(reviewId))
        {
            Console.WriteLine("Error: The review with this ID does not exist.");
            return;
        }
        _reviewRepository.DeleteReview(reviewId);
        Console.WriteLine($"Review Id: {reviewId} has been deleted.");
    }

    public void updateReview()
    {
        Console.WriteLine("Please enter the ReviewId: ");
        // Check if the ReviewId does exist in the Reviews table
        int reviewId = int.Parse(Console.ReadLine());
        if (!_reviewRepository.ReviewExists(reviewId))
        {
            Console.WriteLine("Error: The review with this ID does not exist.");
            return;
        }
        
        var review = new Review();
        
        review.Id = reviewId;
        Console.WriteLine("Please enter the comment you would like to update: ");
        review.Comment =  Console.ReadLine();
        review.CreatedAt = DateTime.UtcNow;
        _reviewRepository.UpdateReview(review);
    }
    
    public void run()
    {
        int choice = -1;

        while (choice != 0)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add Review");
            Console.WriteLine("2. Delete Review");
            Console.WriteLine("3. Update Review");
            Console.WriteLine("4. Print Reviews by Movie ID");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Your choice: ");
            
            choice = int.Parse(Console.ReadLine());
            
            switch (choice)
            {
                case 1:
                    addReview();
                    break;
                case 2: 
                    deleteReview();
                    break;
                case 3:
                    updateReview();
                    break;
                case 4:
                    printReviewsByMovieId();
                    break;
                case 0:
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}