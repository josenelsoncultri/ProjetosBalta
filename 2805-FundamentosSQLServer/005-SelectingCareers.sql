CREATE OR ALTER VIEW vwCareers AS
SELECT
	Career.Id,
	Career.Title,
	Career.Url,
	COUNT(Career.Id) AS Courses
FROM Career
LEFT JOIN CareerItem ON CareerItem.CareerId = Career.Id
GROUP BY Career.Id, Career.Title, Career.Url
GO

SELECT * FROM vwCareers