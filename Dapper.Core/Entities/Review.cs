namespace Dapper.Core.Entities;

public class Review
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int MovieId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    // Navigation property
    public Movie Movie { get; set; }
    
}