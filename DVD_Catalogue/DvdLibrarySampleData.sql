Use DvdCatalogDBFirst
Go

IF EXISTS(Select * From INFORMATION_SCHEMA.ROUTINES
	where Routine_Name = 'DvdLibrarySampleData')
	Drop Procedure DvdLibrarySampleData
Go

Create Procedure DvdLibrarySampleData AS
Begin
	Delete from Dvds;
	Delete from Ratings;

	DBCC CHECKIDENT('Dvds',RESEED,0)
	
	Insert into Ratings(RatingId,RatingDescription)
		Values	('PG','Parental Guidance'),
				('G','Suitable for audiences of all age'),
				('PG-13','Parental Guidance and not suitable for kids below 13'),
				('R','Restricted, not suitable for anyone below 18');

	Set Identity_Insert Dvds on;
	Insert into Dvds(DvdId,Title,ReleaseYear,Director,RatingId,Notes)
		Values  (1,'Taare Zameen Par',2015,'Kalpana Yadav','PG','Excellent movie for parents of school going kids'), 
				(2,'Jumanji',1995,'Steve Spielberg','PG-13','Exciting family movie');
	Set Identity_Insert Dvds off;
End
GO
