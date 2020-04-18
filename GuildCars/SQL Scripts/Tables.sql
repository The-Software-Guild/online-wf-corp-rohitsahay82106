use GuildCars;
Go

IF EXISTS(SELECT * FROM sys.tables WHERE name='Sales')
	DROP TABLE Sales
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='Vehicles')
	DROP TABLE Vehicles
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='Specials')
	DROP TABLE Specials
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='VehicleTransmissionType')
	DROP TABLE VehicleTransmissionType
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='VehicleBodyType')
	DROP TABLE VehicleBodyType
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='VehicleStatus')
	DROP TABLE VehicleStatus
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='VehicleType')
	DROP TABLE VehicleType
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='VehicleMakeModel')
	DROP TABLE VehicleMakeModel
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='VehicleMake')
	DROP TABLE VehicleMake
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='VehicleInteriorColor')
	DROP TABLE VehicleInteriorColor
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='VehicleExteriorColor')
	DROP TABLE VehicleExteriorColor
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='Customers')
	DROP TABLE Customers
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='Addresses')
	DROP TABLE Addresses
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='States')
	DROP TABLE States
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='PurchaseType')
	DROP TABLE PurchaseType
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='GeneralInquiries')
	DROP TABLE GeneralInquiries
GO


Create Table VehicleTransmissionType(
	VehicleTransmissionTypeID int identity(1,1) not null Primary Key,
	VehicleTransmissionTypeDesc	varchar(30) not null,
)

Create Table VehicleBodyType(
	VehicleBodyTypeID int identity(1,1) not null Primary Key,
	VehicleBodyTypeDesc	varchar(30) not null,
)

Create Table VehicleType(
	VehicleTypeID		int identity(1,1) not null Primary Key,
	VehicleTypeDesc	varchar(30) not null,
)

Create Table VehicleMake(
	VehicleMakeID	int identity(1,1) not null Primary Key,
	VehicleMakeDesc	varchar(30) not null,
	VehicleMakeAddedDate date not null default(getdate()),
	UserID nvarchar(128) not null,
)

Create Table VehicleMakeModel(
	VehicleMakeModelID	int identity(1,1) not null Primary Key,
	VehicleMakeID	int not null, 
	VehicleModelDesc varchar(30) not null,
	VehicleMakeModelAddedDate date not null default(getdate()),
	UserID nvarchar(128) not null, 
	Constraint FK_VehicleMake_VehicleMakeModel
				Foreign Key (VehicleMakeID)
				References VehicleMake(VehicleMakeID),
)

Create Table VehicleExteriorColor(
	VehicleExteriorColorID int identity(1,1) not null Primary Key,
	VehicleExteriorColorDesc varchar(30) not null,
)

Create Table VehicleInteriorColor(
	VehicleInteriorColorID int identity(1,1) not null Primary Key,
	VehicleInteriorColorDesc varchar(30) not null,
)


Create Table Vehicles(
	VehicleID int identity(1,1) not null primary key,
	VehicleVinNumber char(17) not null,
	VehicleMakeModelID int not null,
	VehicleMakeYear smallint not null,
	VehicleTypeID int not null,
	VehicleTransmissionTypeID int not null,
	VehicleBodyTypeID int not null,
	VehicleExteriorColorID int not null,
	VehicleInteriorColorID int not null,
	VehicleMileage int not null,
	VehicleMSRP decimal(8,2) not null,
	VehicleSalePrice decimal(8,2) not null,
	VehicleDescription varchar(500) not null,
	VehicleImageFileName varchar(50) not null,
	VehicleOnFeaturedList bit not null default 0,
	VehicleAddedToInventoryDate date not null default(getdate()),
	VehicleRemovedFromInventoryDate date not null default '9999-12-31',
	Constraint FK_VehicleType_Vehicles
				Foreign Key (VehicleTypeID)
				References VehicleType(VehicleTypeID),
	Constraint FK_VehicleBodyType_Vehicles
				Foreign Key (VehicleBodyTypeID)
				References VehicleBodyType(VehicleBodyTypeID),
	Constraint FK_VehicleTransmissionType_Vehicles
				Foreign Key (VehicleTransmissionTypeID)
				References VehicleTransmissionType(VehicleTransmissionTypeID),
	Constraint FK_VehicleMakeModel_Vehicles
				Foreign Key (VehicleMakeModelID)
				References VehicleMakeModel(VehicleMakeModelID),
	Constraint FK_VehicleExteriorColor_Vehicles
				Foreign Key (VehicleExteriorColorID)
				References VehicleExteriorColor(VehicleExteriorColorID),
	Constraint FK_VehicleInteriorColor_Vehicles
				Foreign Key (VehicleInteriorColorID)
				References VehicleInteriorColor(VehicleInteriorColorID),
)
Go

CREATE TABLE States (
	StateID char(2) not null primary key,
	StateName varchar(15) not null
)

Create Table Addresses(
	AddressID int identity(1,1) not null primary key,
	StreetAddressLine1 varchar(100) not null,
	StreetAddressLine2 varchar(100),
	City varchar(50) not null,
	ZipCode char(5) not null,
	StateID char(2) not null,
	Constraint FK_States_Addresses
				Foreign Key (StateID)
				References States(StateID),


)

Create Table Customers(
	CustomerID int identity(1,1) not null primary key,
	CustomerFullName varchar(50) not null,
	CustomerEmailAddress nvarchar(100) not null,
	CustomerPhoneNumber varchar(12) not null,
	CustomerAddressID int not null,
	Constraint FK_Addresses_Customers
				Foreign Key (CustomerAddressID)
				References Addresses(AddressID),

)

Go

Create Table Specials(
	SpecialsID int identity(1,1) not null primary key,
	SpecialsTitle nvarchar(50) not null,
	SpecialsDescription nvarchar(500) not null,
	SpecialsEffectiveDate date not null default(getdate()),
	SpecialsExpirationDate date not null default '9999-12-31',
)

Go

Create Table PurchaseType(
	PurchaseTypeID int identity(1,1) not null primary key,
	PurchaseTypeDesc varchar(50) not null,
)

Create Table Sales(
	SaleID int identity(1,1) not null primary key,
	CustomerID int not null,
	VehicleID int not null,
	UserID nvarchar(128) not null,
	PurchasePrice decimal(8,2) not null,
	PurchaseTypeID int not null,
	SaleDate date not null default(getdate()),
	Constraint FK_Customers_Sales
				Foreign Key (CustomerID)
				References Customers(CustomerID),
	Constraint FK_Vehicles_Sales
				Foreign Key (VehicleID)
				References Vehicles(VehicleID),
	Constraint FK_PurchaseType_Sales
				Foreign Key (PurchaseTypeID)
				References PurchaseType(PurchaseTypeID),
)
Go

Create Table GeneralInquiries(
	GeneralInquiriesID int identity(1,1) not null primary key,
	InquiringEntityName varchar(50) not null,
	InquiringEntityEmail nvarchar(100) null,  
	InquiringEntityPhone varchar(12) null, 
	GeneralInquiryMessage nvarchar(500) not null,
	GeneralInquiryLogDate date not null default(getdate())
	   
)
Go