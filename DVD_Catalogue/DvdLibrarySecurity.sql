USE master
GO

CREATE LOGIN DvdLibraryApp WITH PASSWORD='testing123'
GO

USE DvdCatalogDBFirst
GO

CREATE USER DvdLibraryApp FOR LOGIN DvdLibraryApp
GO

GRANT EXECUTE ON GetAllDvds TO DvdLibraryApp
GRANT EXECUTE ON GetDvdsByDirector TO DvdLibraryApp
GRANT EXECUTE ON GetDvdsByTitle TO DvdLibraryApp
GRANT EXECUTE ON GetDvdsByReleaseYear TO DvdLibraryApp
GRANT EXECUTE ON GetDvdsByRating TO DvdLibraryApp
GRANT EXECUTE ON GetDvdsById TO DvdLibraryApp
GRANT EXECUTE ON AddNewDVD TO DvdLibraryApp
GRANT EXECUTE ON UpdateDvd TO DvdLibraryApp
GRANT EXECUTE ON DeleteDvd TO DvdLibraryApp
GO