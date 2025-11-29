CREATE DATABASE eShopDb;
GO

USE eShopDb;
GO

CREATE TABLE Movies (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    Price DECIMAL(5,2) NOT NULL
);

CREATE TABLE Reviews (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MovieId INT NOT NULL,
    UserId INT NOT NULL,
    Rating INT NOT NULL CHECK (Rating BETWEEN 1 AND 5),
    Comment NVARCHAR(1000),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Reviews_Movies FOREIGN KEY (MovieId) REFERENCES Movies(Id)
);

INSERT INTO Movies (Title, Price) VALUES 
('Avatar', 15.99),
('The Dark Knight', 12.50),
('Top Gun Maverick', 14.00);

INSERT INTO Reviews (MovieId, UserId, Rating, Comment) VALUES
(1, 101, 5, 'Amazing visuals!'),
(2, 202, 4, 'Great movie, good action.'),
(3, 303, 5, 'Loved it!');

SELECT * FROM Movies;
SELECT * FROM Reviews;

SELECT r.Id, r.MovieId, m.Title, r.Rating, r.Comment FROM Movies m JOIN Reviews r ON m.Id = r.MovieId;