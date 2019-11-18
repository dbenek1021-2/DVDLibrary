USE DVDLibrary
GO

INSERT INTO Director(DirectorName)
	VALUES('Steven Spielberg'),
		('Tim Burton'),
		('Ron Howard'),
		('George Lucas'),
		('Joss Whedon')
	GO

INSERT INTO Rating(RatingName)
	VALUES('G'),
		('PG'),
		('PG-13'),
		('R'),
		('NC-17')
	GO


INSERT INTO DVD(Title, ReleaseYear, RatingId, DirectorId, Notes)
	VALUES('Jaws', 1975, 2, 1, 'This movie bites!'),
		('Alice in Wonderland', 2010, 2, 2, 'This movie grows on you.'),
		('Apollo 13', 1995, 2, 3, 'Houston, we have a problem.'),
		('Star Wars: A New Hope', 1977, 2, 4, 'That is not a moon.'),
		('The Avengers', 2012, 3, 5, 'Made me in the mood for shawarma.')
	GO