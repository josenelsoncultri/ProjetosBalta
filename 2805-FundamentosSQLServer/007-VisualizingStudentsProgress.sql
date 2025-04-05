DECLARE @StudentId UNIQUEIDENTIFIER = '014B38ED-C48C-4A3C-B9CF-EC9F00973017'

SELECT
	Student.Name AS Student,
	Course.Title AS Course,
	StudentCourse.Progress,
	StudentCourse.LastUpdateDate
FROM StudentCourse
INNER JOIN Student ON (Student.Id = StudentCourse.StudentId)
INNER JOIN Course ON (Course.Id = StudentCourse.CourseId)
WHERE 1 = 1
AND Student.Id = @StudentId
AND StudentCourse.Progress < 100
AND StudentCourse.Progress > 0
ORDER BY StudentCourse.LastUpdateDate DESC