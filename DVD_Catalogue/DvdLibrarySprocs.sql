Use DvdCatalogDBFirst
Go

IF EXISTS(Select * From INFORMATION_SCHEMA.ROUTINES
	where Routine_Name = 'GetAllDvds')
	Drop Procedure GetAllDvds
Go
IF EXISTS(Select * From INFORMATION_SCHEMA.ROUTINES
	where Routine_Name = 'GetDvdsByDirector')
	Drop Procedure GetDvdsByDirector
Go
IF EXISTS(Select * From INFORMATION_SCHEMA.ROUTINES
	where Routine_Name = 'GetDvdsByTitle')
	Drop Procedure GetDvdsByTitle
Go
IF EXISTS(Select * From INFORMATION_SCHEMA.ROUTINES
	where Routine_Name = 'GetDvdsByReleaseYear')
	Drop Procedure GetDvdsByReleaseYear
Go
IF EXISTS(Select * From INFORMATION_SCHEMA.ROUTINES
	where Routine_Name = 'GetDvdsByRating')
	Drop Procedure GetDvdsByRating
Go
IF EXISTS(Select * From INFORMATION_SCHEMA.ROUTINES
	where Routine_Name = 'GetDvdsById')
	Drop Procedure GetDvdsById
Go
IF EXISTS(Select * From INFORMATION_SCHEMA.ROUTINES
	where Routine_Name = 'AddNewDVD')
	Drop Procedure AddNewDVD
Go
IF EXISTS(Select * From INFORMATION_SCHEMA.ROUTINES
	where Routine_Name = 'UpdateDvd')
	Drop Procedure UpdateDvd
Go
IF EXISTS(Select * From INFORMATION_SCHEMA.ROUTINES
	where Routine_Name = 'DeleteDvd')
	Drop Procedure DeleteDvd
Go

Create Procedure GetAllDvds
AS
Begin
	Select DvdId,Title,ReleaseYear,Director,RatingId,Notes
		From Dvds;
End
Go

Create Procedure GetDvdsByDirector(
	@director nvarchar(50)
)
AS
Begin
	Select DvdId,Title,ReleaseYear,Director,RatingId,Notes
		From Dvds
		Where Director LIKE '%'+ @director + '%';
End
Go

Create Procedure GetDvdsByTitle(
	@title nvarchar(120)
)
AS
Begin
	Select DvdId,Title,ReleaseYear,Director,RatingId,Notes
		From Dvds
		Where Title LIKE '%'+ @title + '%';
End
Go

Create Procedure GetDvdsByReleaseYear(
	@releaseYear smallint
)
AS
Begin
	Select DvdId,Title,ReleaseYear,Director,RatingId,Notes
		From Dvds
		Where ReleaseYear = @releaseYear;
End
Go

Create Procedure GetDvdsByRating(
	@rating nvarchar(5)
)
AS
Begin
	Select DvdId,Title,ReleaseYear,Director,RatingId,Notes
		From Dvds
		Where RatingId = @rating;
End
Go

Create Procedure GetDvdsById(
	@id int 
)
AS
Begin
	Select DvdId,Title,ReleaseYear,Director,RatingId,Notes
		From Dvds
		Where DvdId = @id; 
End
Go

Create Procedure AddNewDVD(
	@dvdId int output,
	@title nvarchar(120),  
	@releaseYear smallint,
	@director nvarchar(50),
	@rating nvarchar(5), 
	@notes nvarchar(120)
)
AS
Begin
	INSERT INTO Dvds(Title,Director,ReleaseYear,RatingId,Notes)
			VALUES (@title,@director,@releaseYear,@rating,@notes);
	SET @dvdId = SCOPE_IDENTITY();
End
Go

Create Procedure UpdateDvd(
	@dvdId int,
	@title nvarchar(120),  
	@releaseYear smallint,
	@director nvarchar(50),
	@rating nvarchar(5), 
	@notes nvarchar(120)
)
AS
Begin
	Update Dvds Set
			Title = @title,
			Director=@director,
			ReleaseYear=@releaseYear,
			RatingId=@rating,
			Notes=@notes
	
	Where DvdId = @dvdId;	
End
Go

Create Procedure DeleteDvd(
	@dvdId int
)
AS
Begin
	Delete from Dvds where DvdId = @dvdId;
End
Go