Use GuildCars
Go

Drop View If Exists dbo.AllAvailableVehicles;
Go
Drop View If Exists dbo.AllSalesRecord;
Go

Create View AllAvailableVehicles
AS
Select	a.VehicleID,a.VehicleDescription, a.VehicleSalePrice,a.VehicleMSRP,
			a.VehicleVinNumber,a.VehicleImageFileName,a.VehicleMakeYear, a.VehicleMileage,
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
	Where	a.VehicleAddedToInventoryDate <= GETDATE() and
			a.VehicleRemovedFromInventoryDate > GETDATE();
Go

Create View AllSalesRecord
AS
Select a.SaleID, a.PurchasePrice,a.SaleDate,a.VehicleID,
		b.UserName,b.FirstName,b.LastName

	From Sales a
		 inner join AspNetUsers b on
				a.UserID = b.Id;
Go