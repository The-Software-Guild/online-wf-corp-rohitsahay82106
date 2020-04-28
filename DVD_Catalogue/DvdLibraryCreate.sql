use master;
Go
if exists (select * from sysdatabases where name='DvdCatalogDBFirst')
		drop database DvdCatalogDBFirst
GO
create Database DvdCatalogDBFirst;
GO


use DvdCatalogDBFirst;
Go
IF EXISTS(SELECT * FROM sys.tables WHERE name='Dvds')
	DROP TABLE Dvds
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='Ratings')
	DROP TABLE Ratings
GO

Create Table Ratings(
	RatingId nvarchar(5) not null Primary Key,
	RatingDescription nvarchar(120),
	
)
GO
Create Table Dvds(
	DvdId int identity(1,1) not null Primary Key,
	Title nvarchar(120) not null, 
	ReleaseYear smallint not null,
	Director nvarchar(50) not null,
	RatingId nvarchar(5) not null,
	Notes nvarchar(120),
	Constraint FK_Ratings_Dvds
				Foreign Key (RatingId)
				References Ratings(RatingId),
)
GO