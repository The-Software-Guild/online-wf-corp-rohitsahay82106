Use GuildCars
Go

IF EXISTS(Select * From INFORMATION_SCHEMA.ROUTINES
	where Routine_Name = 'GetVehicleTransmissionType')
	Drop Procedure GetVehicleTransmissionType
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetAllVehicleTransmissionType')
	Drop Procedure GetAllVehicleTransmissionType
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetAllVehicleType')
	Drop Procedure GetAllVehicleType
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetAllVehicleInteriorColor')
	Drop Procedure GetAllVehicleInteriorColor
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetAllVehicleExteriorColor')
	Drop Procedure GetAllVehicleExteriorColor
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetAllVehicleBodyType')
	Drop Procedure GetAllVehicleBodyType
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetAllStates')
	Drop Procedure GetAllStates
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetAllPurchaseType')
	Drop Procedure GetAllPurchaseType
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'AddNewVehicleMake')
	Drop Procedure AddNewVehicleMake
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'AddNewVehicleMakeModel')
	Drop Procedure AddNewVehicleMakeModel
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'AddNewVehicle')
	Drop Procedure AddNewVehicle
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetAllFeaturedVehicles')
	Drop Procedure GetAllFeaturedVehicles
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetVehicleByID')
	Drop Procedure GetVehicleByID
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'EditVehicle')
	Drop Procedure EditVehicle
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DeleteVehicle')
	Drop Procedure DeleteVehicle
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'AddNewAddress')
	Drop Procedure AddNewAddress
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'AddNewCustomer')
	Drop Procedure AddNewCustomer
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'AddSalesRecord')
	Drop Procedure AddSalesRecord
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'PurchaseVehicle')
	Drop Procedure PurchaseVehicle
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'MarkVehiclesSold')
	Drop Procedure MarkVehiclesSold
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetAllSpecials')
	Drop Procedure GetAllSpecials
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DeleteSpecials')
	Drop Procedure DeleteSpecials
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'AddNewSpecials')
	Drop Procedure AddNewSpecials
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetAllVehicleMakeModel')
	Drop Procedure GetAllVehicleMakeModel
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetAllVehicleMake')
	Drop Procedure GetAllVehicleMake
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'LogGeneralInquiry')
	Drop Procedure LogGeneralInquiry
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetVehicleModels')
	Drop Procedure GetVehicleModels
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetVehicleForEdit')
	Drop Procedure GetVehicleForEdit
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetVehicleMakeID')
	Drop Procedure GetVehicleMakeID
Go
IF Exists(Select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetInventoryReports')
	Drop Procedure GetInventoryReports
Go

Create Procedure GetVehicleTransmissionType(
	@id int
)
AS
Begin
	Select VehicleTransmissionTypeDesc from VehicleTransmissionType
		where VehicleTransmissionTypeID = @id;
End
Go

Create Procedure GetAllVehicleTransmissionType
AS
Begin
	Select VehicleTransmissionTypeID, VehicleTransmissionTypeDesc
		From VehicleTransmissionType;
End
Go

Create Procedure GetAllVehicleType
As 
Begin
	Select VehicleTypeID, VehicleTypeDesc 
		From VehicleType;
End
Go

Create Procedure GetAllVehicleInteriorColor
As
Begin
	Select VehicleInteriorColorID, VehicleInteriorColorDesc
		From VehicleInteriorColor;
End
Go

Create Procedure GetAllVehicleExteriorColor
As
Begin
	Select VehicleExteriorColorID, VehicleExteriorColorDesc
		From VehicleExteriorColor;
End
Go

Create Procedure GetAllVehicleBodyType
As
Begin
	Select VehicleBodyTypeID, VehicleBodyTypeDesc
		From VehicleBodyType;
End
Go

Create Procedure GetAllStates
AS
Begin
	Select StateID, StateName
		From States;
End
Go

Create Procedure GetAllPurchaseType
As
Begin
	Select PurchaseTypeID, PurchaseTypeDesc
		From PurchaseType;
End
Go

Create Procedure AddNewVehicleMake(
	@VehicleMakeID int output,
	@VehicleMakeDesc varchar(30),
	@UserId nvarchar(128)
)
AS
Begin
	INSERT INTO VehicleMake(UserId, VehicleMakeDesc)
	VALUES (@UserId, @VehicleMakeDesc) ;
	SET @VehicleMakeID = SCOPE_IDENTITY();
End
Go

Create Procedure AddNewVehicleMakeModel(
	@VehicleMakeModelID int output,
	@VehicleMakeID int,
	@VehicleModelDesc varchar(30),
	@UserId nvarchar(128)
)
AS
Begin
	INSERT INTO VehicleMakeModel(UserId, VehicleModelDesc, VehicleMakeID)
	VALUES (@UserId, @VehicleModelDesc, @VehicleMakeID) ;
	SET @VehicleMakeModelID = SCOPE_IDENTITY();
End
Go

Create Procedure AddNewVehicle(
	@VehicleID int output,
	@VehicleVinNumber char(17),
	@VehicleMakeModelID int,
	@VehicleMakeYear smallint,
	@VehicleTypeID int,
	@VehicleTransmissionTypeID int,
	@VehicleBodyTypeID int,
	@VehicleExteriorColorID int,
	@VehicleInteriorColorID int,
	@VehicleMileage int,
	@VehicleMSRP decimal(8,2),
	@VehicleSalePrice decimal(8,2),
	@VehicleDescription varchar(500),
	@VehicleImageFileName varchar(50)
)
AS
Begin
	Insert into Vehicles(VehicleVinNumber, VehicleMakeModelID, VehicleMakeYear,VehicleTypeID,
							VehicleTransmissionTypeID, VehicleBodyTypeID, VehicleExteriorColorID,
							VehicleInteriorColorID, VehicleMileage,VehicleMSRP, VehicleSalePrice,
							VehicleDescription, VehicleImageFileName)
			Values (@VehicleVinNumber, @VehicleMakeModelID, @VehicleMakeYear, @VehicleTypeID,
					@VehicleTransmissionTypeID, @VehicleBodyTypeID, @VehicleExteriorColorID,
					@VehicleInteriorColorID, @VehicleMileage, @VehicleMSRP,@VehicleSalePrice,
					@VehicleDescription, @VehicleImageFileName);
	Set @VehicleID = SCOPE_IDENTITY();
End
Go

Create Procedure GetAllFeaturedVehicles
AS
Begin
	Select	a.VehicleID, a.VehicleMakeYear, c.VehicleMakeDesc,b.VehicleModelDesc, 
			a.VehicleSalePrice, a.VehicleImageFileName 
		From Vehicles a 
			inner join VehicleMakeModel b on 
					a.VehicleMakeModelID = b.VehicleMakeModelID
			inner join VehicleMake c on
					b.VehicleMakeID = c.VehicleMakeID
		Where a.VehicleOnFeaturedList = 1 and
				a.VehicleAddedToInventoryDate <= GETDATE() and
				a.VehicleRemovedFromInventoryDate > GETDATE();
End
Go

Create Procedure GetVehicleByID(
	@VehicleID int
)
AS
Begin
	Select	a.VehicleID,a.VehicleDescription, a.VehicleSalePrice,a.VehicleMSRP,
			a.VehicleVinNumber,a.VehicleImageFileName,a.VehicleMakeYear,a.VehicleMileage,
			b.VehicleTypeDesc,c.VehicleTransmissionTypeDesc,d.VehicleBodyTypeDesc,
			e.VehicleModelDesc, f.VehicleMakeDesc,g.VehicleExteriorColorDesc,h.VehicleInteriorColorDesc
	From	Vehicles a
			inner join VehicleType b on
					a.VehicleTypeID = b.VehicleTypeID
			inner join VehicleTransmissionType c on
					a.VehicleTransmissionTypeID = c.VehicleTransmissionTypeID
			inner join VehicleBodyType d on
					a.VehicleBodyTypeID = d.VehicleBodyTypeID
			inner join VehicleMakeModel e on
					a.VehicleMakeModelID = e.VehicleMakeModelID
			inner join VehicleMake f on
					e.VehicleMakeID = f.VehicleMakeID
			inner join VehicleExteriorColor g on
					a.VehicleExteriorColorID = g.VehicleExteriorColorID
			inner join VehicleInteriorColor h on
					a.VehicleInteriorColorID = h.VehicleInteriorColorID
	Where a.VehicleID = @VehicleID; 

End
Go

Create Procedure EditVehicle(
	@VehicleID int,
	@VehicleVinNumber char(17),
	@VehicleMakeModelID int,
	@VehicleMakeYear smallint,
	@VehicleTypeID int,
	@VehicleTransmissionTypeID int,
	@VehicleBodyTypeID int,
	@VehicleExteriorColorID int,
	@VehicleInteriorColorID int,
	@VehicleMileage int,
	@VehicleMSRP decimal(8,2),
	@VehicleSalePrice decimal(8,2),
	@VehicleDescription varchar(500),
	@VehicleImageFileName varchar(50),
	@VehicleOnFeaturedList bit
)
AS
Begin
	Update Vehicles Set
			VehicleVinNumber = @VehicleVinNumber, 
			VehicleMakeModelID = @VehicleMakeModelID, 
			VehicleMakeYear = @VehicleMakeYear,
			VehicleTypeID = @VehicleTypeID,
			VehicleTransmissionTypeID = @VehicleTransmissionTypeID, 
			VehicleBodyTypeID = @VehicleBodyTypeID, 
			VehicleExteriorColorID = @VehicleExteriorColorID,
			VehicleInteriorColorID = @VehicleInteriorColorID, 
			VehicleMileage = @VehicleMileage,
			VehicleMSRP = @VehicleMSRP, 
			VehicleSalePrice = @VehicleSalePrice,
			VehicleDescription = @VehicleDescription, 
			VehicleImageFileName = @VehicleImageFileName,
			VehicleOnFeaturedList = @VehicleOnFeaturedList
	
	Where VehicleID = @VehicleID;	
End
Go

Create Procedure DeleteVehicle(
	@VehicleID int
)
AS
Begin
	Delete from Vehicles where VehicleID = @VehicleID;
End
Go

Create Procedure AddNewAddress(
	@AddressID int output,
	@StreetAddressLine1 varchar(100),
	@StreetAddressLine2 varchar(100),
	@City varchar(50),
	@ZipCode decimal(5),
	@StateID char(2)
)
AS
Begin
	Insert into Addresses(StreetAddressLine1,StreetAddressLine2,City,ZipCode,StateID)
			values(@StreetAddressLine1,@StreetAddressLine2,@City,@ZipCode,@StateID);
	Set @AddressID = SCOPE_IDENTITY();
End
Go

Create Procedure AddNewCustomer(
	@CustomerID int output,
	@CustomerFullName varchar(50),
	@CustomerEmailAddress nvarchar(100),
	@CustomerPhoneNumber varchar(12),
	@CustomerAddressID int
)
AS
Begin
	Insert into Customers(CustomerFullName,CustomerEmailAddress,CustomerPhoneNumber,CustomerAddressID)
		values(@CustomerFullName,@CustomerEmailAddress,@CustomerPhoneNumber,@CustomerAddressID);
	Set @CustomerID = SCOPE_IDENTITY();
End
Go

Create Procedure AddSalesRecord(
	@SaleID int output,
	@CustomerID int,
	@VehicleID int,
	@UserID nvarchar(128),
	@PurchasePrice decimal(8,2),
	@PurchaseTypeID int      
)
AS
Begin
	Insert into Sales(CustomerID,VehicleID,UserID,PurchasePrice,PurchaseTypeID)
		values(@CustomerID,@VehicleID,@UserID,@PurchasePrice,@PurchaseTypeID);
	Set @SaleID = SCOPE_IDENTITY();

End
Go

Create Procedure MarkVehiclesSold(
	@VehicleID int
)
AS
Begin
	Update Vehicles
		Set VehicleRemovedFromInventoryDate = GETDATE()
	Where VehicleID = @VehicleID;
End
Go

Create Procedure PurchaseVehicle(
	@AddressID int output,
	@StreetAddressLine1 varchar(100),
	@StreetAddressLine2 varchar(100),
	@City varchar(50),
	@ZipCode decimal(5),
	@StateID char(2),
	@CustomerFullName varchar(50),
	@CustomerEmailAddress nvarchar(100),
	@CustomerPhoneNumber varchar(12),
	@CustomerID int output,
	@VehicleID int,
	@UserID nvarchar(128),
	@PurchasePrice decimal(8,2),
	@PurchaseTypeID int,
	@SaleID int	output
)
AS
Begin
	Begin Transaction
		Declare @num INT, @num1 INT, @num2 INT;
		Exec AddNewAddress @AddressID=@num output,@StreetAddressLine1=@StreetAddressLine1,@StreetAddressLine2=@StreetAddressLine2,@City=@City,@ZipCode=@ZipCode,@StateID=@StateID;
		Exec AddNewCustomer @CustomerID=@num1 output,@CustomerFullName=@CustomerFullName,@CustomerEmailAddress=@CustomerEmailAddress,@CustomerPhoneNumber=@CustomerPhoneNumber,@CustomerAddressID=@num;
		Exec AddSalesRecord @SaleID=@num2 output,@CustomerID=@num1,@VehicleID=@VehicleID,@UserID=@UserID,@PurchasePrice=@PurchasePrice,@PurchaseTypeID=@PurchaseTypeID;
		Exec MarkVehiclesSold @VehicleID=@VehicleID;
	Commit Transaction

End
Go

Create Procedure AddNewSpecials(
	@SpecialsID int output,
	@SpecialsTitle nvarchar(50),
	@SpecialsDescription nvarchar(500)
)
AS
Begin
		Insert into Specials(SpecialsTitle,SpecialsDescription)
				values(@SpecialsTitle,@SpecialsDescription);
		Set @SpecialsID = SCOPE_IDENTITY();
End
Go

Create Procedure DeleteSpecials(
	@SpecialsID int	
)
AS
Begin
		Delete from Specials
			where SpecialsID = @SpecialsID;
End
Go

Create Procedure GetAllSpecials
AS
Begin
	Select SpecialsID, SpecialsTitle, SpecialsDescription, SpecialsEffectiveDate, SpecialsExpirationDate
		From Specials 
		where SpecialsEffectiveDate <= GETDATE() and SpecialsExpirationDate >= GETDATE();
End
Go

Create Procedure GetAllVehicleMake
AS
Begin
	Select VehicleMakeID, VehicleMakeDesc,VehicleMakeAddedDate, UserID
		From VehicleMake;
End
Go

Create Procedure GetAllVehicleMakeModel
AS
Begin
	Select a.VehicleMakeModelID,b.VehicleMakeDesc,a.VehicleModelDesc,a.VehicleMakeModelAddedDate,a.UserID
		From VehicleMakeModel a 
			inner join VehicleMake b on
				a.VehicleMakeID = b.VehicleMakeID;

				
End
Go

Create Procedure LogGeneralInquiry(
	@GeneralInquiriesID int output,
	@InquiringEntityName varchar(50), 
	@InquiringEntityEmail nvarchar(100), 
	@InquiringEntityPhone varchar(12),
	@GeneralInquiryMessage nvarchar(500)
)
AS
Begin
		Insert into GeneralInquiries(InquiringEntityName,InquiringEntityEmail,InquiringEntityPhone,GeneralInquiryMessage)
				values(@InquiringEntityName,@InquiringEntityEmail,@InquiringEntityPhone,@GeneralInquiryMessage);
		Set @GeneralInquiriesID = SCOPE_IDENTITY();
End
Go

Create Procedure GetVehicleModels(
	@VehicleMakeID int
)
As
Begin
		Select VehicleMakeModelID,VehicleModelDesc,UserID,VehicleMakeID,VehicleMakeModelAddedDate
			From VehicleMakeModel
			Where VehicleMakeID = @VehicleMakeID;
End
Go

Create Procedure GetVehicleForEdit(
	@VehicleID int
)
AS
Begin
		Select VehicleID, VehicleVinNumber, VehicleMakeModelID, VehicleMakeYear,VehicleTypeID,
				VehicleTransmissionTypeID, VehicleBodyTypeID, VehicleExteriorColorID,
				VehicleInteriorColorID, VehicleMileage,VehicleMSRP, VehicleSalePrice,
				VehicleDescription, VehicleImageFileName, VehicleOnFeaturedList,VehicleAddedToInventoryDate,VehicleRemovedFromInventoryDate
			From Vehicles
			Where VehicleID = @VehicleID;
End
Go

Create Procedure GetVehicleMakeID(
	@VehicleMakeModelID int
)
AS
Begin
		Select VehicleMakeID
			From VehicleMakeModel
			Where VehicleMakeModelID = @VehicleMakeModelID;
End
Go

Create Procedure GetInventoryReports(
	@VehicleTypeID int
)
AS
Begin
	Select	a.VehicleMakeYear, c.VehicleMakeDesc,b.VehicleModelDesc, 
			Count(a.VehicleID) AS VehicleCount, Sum(a.VehicleMSRP) AS VehicleStockValue 
		From Vehicles a 
			inner join VehicleMakeModel b on 
					a.VehicleMakeModelID = b.VehicleMakeModelID
			inner join VehicleMake c on
					b.VehicleMakeID = c.VehicleMakeID
		Where a.VehicleTypeID = @VehicleTypeID and
				a.VehicleAddedToInventoryDate <= GETDATE() and
				a.VehicleRemovedFromInventoryDate > GETDATE()
		group by a.VehicleMakeYear, c.VehicleMakeDesc,b.VehicleModelDesc
		order by a.VehicleMakeYear DESC, c.VehicleMakeDesc,b.VehicleModelDesc;
End
Go
