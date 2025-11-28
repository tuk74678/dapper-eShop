using Dapper.Core.Interfaces;
using Dapper.eShop.UI;
using Dapper.Infrastructure.Data;
using Dapper.Infrastructure.Repositories;


// Use DbConnection class to get a SQL connection
var dbConnectionProvider = new DbConnection();
using var dbConnection = dbConnectionProvider.GetConnection();

// Create the repository with the connection
IReviewRepository reviewRepository = new ReviewRepository(dbConnection);

// Create the service and pass the repository
ReviewService reviewService = new ReviewService(reviewRepository);

// Run the service
reviewService.run();

