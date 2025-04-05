CREATE OR ALTER VIEW vwCourses AS
SELECT
	Course.Id, 
	Course.Tag, 
	Course.Title, 
	Course.Url, 
	Course.Summary,
	Category.Title AS Category,
	Author.Name AS Author,
	Course.CreateDate
FROM Course
INNER JOIN Category ON (Category.Id = Course.CategoryId)
INNER JOIN Author ON (Author.Id = Course.AuthorId)
WHERE Active = 1
GO

SELECT * FROM vwCourses ORDER BY CreateDate DESC