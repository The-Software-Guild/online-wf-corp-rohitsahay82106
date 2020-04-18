Use GuildCars
Go

IF EXISTS(Select * From INFORMATION_SCHEMA.ROUTINES
	where Routine_Name = 'DbReset')
	Drop Procedure DbReset
Go

Create Procedure DbReset AS
Begin
	Delete from Sales;
	Delete from Customers;
	Delete from Addresses;
	Delete from Vehicles;
	Delete from VehicleMakeModel;
	Delete from VehicleMake;
	
	Delete from VehicleTransmissionType;
	Delete from VehicleBodyType;
	Delete from VehicleType;
	Delete from VehicleExteriorColor;
	Delete from VehicleInteriorColor;
	Delete from States;
	Delete from PurchaseType;

	DBCC CHECKIDENT('Sales',RESEED,0)
	DBCC CHECKIDENT('Addresses',RESEED,0)
	DBCC CHECKIDENT('Customers',RESEED,0)
	DBCC CHECKIDENT('Vehicles',RESEED,0)
	DBCC CHECKIDENT('VehicleMake',RESEED,0)
	DBCC CHECKIDENT('VehicleMakeModel',RESEED,0)

	Set Identity_Insert VehicleTransmissionType on;
	Insert into VehicleTransmissionType(VehicleTransmissionTypeID, VehicleTransmissionTypeDesc)
	Values (1,'Manual'), (2,'Automatic');
	Set Identity_Insert VehicleTransmissionType off;

	Set Identity_Insert VehicleBodyType on;
	Insert into VehicleBodyType(VehicleBodyTypeID, VehicleBodyTypeDesc)
	Values (1,'Car'), (2,'SUV'), (3,'Truck'), (4,'Van');
	Set Identity_Insert VehicleBodyType off;

	Set Identity_Insert VehicleType on;
	Insert into VehicleType(VehicleTypeID, VehicleTypeDesc)
	values (1,'New'), (2,'Used');
	Set Identity_Insert VehicleType off;

	Set identity_insert VehicleExteriorColor on;
	Insert into VehicleExteriorColor(VehicleExteriorColorID, VehicleExteriorColorDesc)
	Values (1,'Red'),(2,'Blue'),(3,'Green'),(4,'Black'),(5,'White');
	Set identity_insert VehicleExteriorColor off;
	
	Set identity_insert VehicleInteriorColor on;
	Insert into VehicleInteriorColor(VehicleInteriorColorID, VehicleInteriorColorDesc)
	Values (1,'White'),(2,'Black'),(3,'Gray'),(4,'Brown'),(5,'Beige');
	Set identity_insert VehicleInteriorColor off;

	Insert into States(StateID,StateName)
	Values ('OH','Ohio'),('PA','Pennsylvania'),('WV','West Virginia'),('NJ','New Jersey'),
		('MI','Michigan'),('IN','Indiana'),('KY','Kentucky'), ('IA','Iowa');

	Set identity_insert PurchaseType on;
	Insert into PurchaseType(PurchaseTypeID,PurchaseTypeDesc)
	values (1,'Bank Finance'),(2,'Cash'), (3,'Dealer Finance');
	Set Identity_Insert PurchaseType off;
		

End
Go