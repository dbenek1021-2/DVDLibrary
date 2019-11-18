USE master
GO

CREATE LOGIN DvdLibraryApp WITH PASSWORD='testing123'
GO

USE DVDLibrary
GO

CREATE USER DvdLibraryApp FOR LOGIN DvdLibraryApp
GO



GRANT EXECUTE TO DvdLibraryApp
GO

GRANT EXECUTE ON CreateDirector TO DvdLibraryApp
GRANT EXECUTE ON CreateDVD TO DvdLibraryApp
GRANT EXECUTE ON CreateRating TO DvdLibraryApp
GRANT EXECUTE ON DeleteDVD TO DvdLibraryApp
GRANT EXECUTE ON EditDVD TO DvdLibraryApp
GRANT EXECUTE ON GetAllDVDs TO DvdLibraryApp
GRANT EXECUTE ON GetDVDByDirector TO DvdLibraryApp
GRANT EXECUTE ON GetDVDById TO DvdLibraryApp
GRANT EXECUTE ON GetDVDByRating TO DvdLibraryApp
GRANT EXECUTE ON GetDVDByReleaseYear TO DvdLibraryApp
GRANT EXECUTE ON GetDVDByTitle TO DvdLibraryApp
GO

GRANT SELECT ON Director TO DvdLibraryApp
GRANT INSERT ON Director TO DvdLibraryApp
GRANT UPDATE ON Director TO DvdLibraryApp
GRANT DELETE ON Director TO DvdLibraryApp
GO

GRANT SELECT ON Rating TO DvdLibraryApp
GRANT INSERT ON Rating TO DvdLibraryApp
GRANT UPDATE ON Rating TO DvdLibraryApp
GRANT DELETE ON Rating TO DvdLibraryApp
GO

GRANT SELECT ON DVD TO DvdLibraryApp
GRANT INSERT ON DVD TO DvdLibraryApp
GRANT UPDATE ON DVD TO DvdLibraryApp
GRANT DELETE ON DVD TO DvdLibraryApp
GO