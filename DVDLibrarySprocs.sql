USE DVDLibrary
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetAllDVDs')
BEGIN
   DROP PROCEDURE GetAllDVDs
END
GO
CREATE PROCEDURE GetAllDVDs
AS
	SELECT d.DVDId, d.Title, d.ReleaseYear, r.RatingId, r.RatingName, i.DirectorId, i.DirectorName, d.Notes
	FROM DVD d 
		LEFT JOIN Rating r ON d.RatingId = r.RatingId
		LEFT JOIN Director i ON d.DirectorId = i.DirectorId
	ORDER BY Title
GO

IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDVDById')
BEGIN
    DROP PROCEDURE GetDVDById
END
GO
CREATE PROCEDURE GetDVDById (
	@DVDId int
)
AS
	SELECT d.DVDId, d.Title, d.ReleaseYear, r.RatingId, r.RatingName, i.DirectorId, i.DirectorName, d.Notes
	FROM DVD d
	LEFT JOIN Rating r on d.RatingID = r.RatingID
	LEFT JOIN Director i on d.DirectorID = i.DirectorID
	WHERE d.DVDID = @DVDID
	ORDER BY Title
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'CreateDVD')
BEGIN
   DROP PROCEDURE CreateDVD
END
GO
CREATE PROCEDURE CreateDVD
	@Title nvarchar(60),
	@ReleaseYear int,
	@RatingId nvarchar(6),
	@DirectorId int,
	@Notes nvarchar(600)
AS
	INSERT INTO DVD (Title, ReleaseYear, RatingId, DirectorId, Notes)
	VALUES (@Title, @ReleaseYear, @RatingId, @DirectorId, @Notes);

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'EditDVD')
BEGIN
   DROP PROCEDURE EditDVD
END
GO
CREATE PROCEDURE EditDVD
	@DVDId int,
	@Title nvarchar(60),
	@ReleaseYear int,
	@RatingId nvarchar(6),
	@DirectorId int,
	@Notes nvarchar(600)
AS
	UPDATE DVD
	SET Title = @Title,
		ReleaseYear = @ReleaseYear,
		RatingId = @RatingId,
		DirectorId = @DirectorId,
		Notes = @Notes
	WHERE DVDId = @DVDId
GO

IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDVDByRating')
BEGIN
    DROP PROCEDURE GetDVDByRating
END
GO
CREATE PROCEDURE GetDVDByRating (
	@RatingName nvarchar(60)
)
AS
	SELECT d.DVDId, d.Title, d.ReleaseYear, r.RatingId, r.RatingName, i.DirectorId, i.DirectorName, d.Notes
	FROM DVD d 
		LEFT JOIN Rating r ON d.RatingId = r.RatingId
		LEFT JOIN Director i ON d.DirectorId = i.DirectorId
	WHERE r.RatingName = @RatingName
	ORDER BY Title
GO

IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDVDByReleaseYear')
BEGIN
    DROP PROCEDURE GetDVDByReleaseYear
END
GO
CREATE PROCEDURE GetDVDByReleaseYear (
	@ReleaseYear int
)
AS
	SELECT d.DVDId, d.Title, d.ReleaseYear, r.RatingId, r.RatingName, i.DirectorId, i.DirectorName, d.Notes
	FROM DVD d 
		LEFT JOIN Rating r ON d.RatingId = r.RatingId
		LEFT JOIN Director i ON d.DirectorId = i.DirectorId
	WHERE d.ReleaseYear = @ReleaseYear
	ORDER BY Title
GO

IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDVDByTitle')
BEGIN
    DROP PROCEDURE GetDVDByTitle
END
GO
CREATE PROCEDURE GetDVDByTitle (
	@Title nvarchar(60)
)
AS
	SELECT d.DVDId, d.Title, d.ReleaseYear, r.RatingId, r.RatingName, i.DirectorId, i.DirectorName, d.Notes
	FROM DVD d 
		LEFT JOIN Rating r ON d.RatingId = r.RatingId
		LEFT JOIN Director i ON d.DirectorId = i.DirectorId
	WHERE d.Title = @Title
	ORDER BY Title
GO

IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDVDByDirector')
BEGIN
    DROP PROCEDURE GetDVDByDirector
END
GO
CREATE PROCEDURE GetDVDByDirector (
	@DirectorName nvarchar(60)
)
AS
	SELECT d.DVDId, d.Title, d.ReleaseYear, r.RatingId, r.RatingName, i.DirectorId, i.DirectorName, d.Notes
	FROM DVD d 
		LEFT JOIN Rating r ON d.RatingId = r.RatingId
		LEFT JOIN Director i ON d.DirectorId = i.DirectorId
	WHERE i.DirectorName = @DirectorName
	ORDER BY Title
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'CreateRating')
BEGIN
   DROP PROCEDURE CreateRating
END
GO
CREATE PROCEDURE CreateRating
	@RatingName nvarchar(60)
AS
	INSERT INTO Rating (RatingName)
	VALUES (@RatingName)
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'CreateDirector')
BEGIN
   DROP PROCEDURE CreateDirector
END
GO
CREATE PROCEDURE CreateDirector
	@DirectorName nvarchar(60)
AS
	INSERT INTO Director (DirectorName)
	VALUES (@DirectorName)
GO

IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteDVD')
BEGIN
    DROP PROCEDURE DeleteDVD
END
GO
CREATE PROCEDURE DeleteDVD (
	@DVDId int
)
AS
	DELETE FROM DVD
	WHERE DVDId = @DVDId
GO

IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDirectorByName')
BEGIN
    DROP PROCEDURE GetDirectorByName
END
GO
CREATE PROCEDURE GetDirectorByName
	@DirectorName nvarchar(60)
AS
	SELECT DirectorId, DirectorName
	FROM Director
	WHERE DirectorName = @DirectorName
GO

IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetRatingByName')
BEGIN
    DROP PROCEDURE GetRatingByName
END
GO
CREATE PROCEDURE GetRatingByName
	@RatingName nvarchar(60)
AS
	SELECT RatingId, RatingName
	FROM Rating
	WHERE RatingName = @RatingName
GO

