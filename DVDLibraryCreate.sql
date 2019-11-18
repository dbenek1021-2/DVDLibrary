USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE Name='DVDLibrary')
DROP DATABASE DVDLibrary
GO

CREATE DATABASE DVDLibrary
GO

USE DVDLibrary
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'DVD')
	DROP TABLE DVD;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'Rating')
	DROP TABLE Rating;
GO

IF EXISTS(SELECT * FROM sys.tables
	WHERE NAME = 'Director')
	DROP TABLE Director;
GO

CREATE TABLE Director (
	DirectorId int identity(1,1) primary key not null,
	DirectorName nvarchar(60) not null
)

CREATE TABLE Rating (
	RatingId int identity(1,1) primary key not null,
	RatingName nvarchar(60) not null
)

CREATE TABLE DVD (
	DVDId int identity(1,1) primary key not null,
	Title nvarchar(60) not null,
	ReleaseYear int not null,
	RatingId int foreign key references Rating(RatingId) not null,
	DirectorId int foreign key references Director(DirectorId) null,
	Notes nvarchar(600) null
)