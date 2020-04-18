using GuildCars.Data.Repository_Prod;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Test.IntegrationTests
{
    [TestFixture]
    public class DrapperTests
    {
        [Test]
        public void runAllVehicleTests()
        {
            CanAddMakes();
            CanAddModel();
            CanAddVehicle();
            CanSearchVehicle();
            CanSearchVehicle2();
            CanGetAllFeaturedVehicle();
            CanPurchaseVehicle();
        }
        
        public void CanAddMakes()
        {
            var repo = new VehiclesDataRepository();
            VehicleMake make = new VehicleMake();
            make.UserID = "User-1";
            make.VehicleMakeDesc = "Honda";
            repo.AddNewVehicleMake(make);
            Assert.AreEqual(1, make.VehicleMakeID);

        }

        public void CanAddModel()
        {
            var repo = new VehiclesDataRepository();
            VehicleMakeModel model = new VehicleMakeModel();
            model.UserID = "User-1";
            model.VehicleMakeID = 1;
            model.VehicleModelDesc = "Accord";
            repo.AddNewVehicleMakeModel(model);
            Assert.AreEqual(1, model.VehicleMakeModelID);

        }

        public void CanAddVehicle()
        {

            var repo = new VehiclesDataRepository();
            Vehicles vehicle = new Vehicles();
            vehicle.VehicleVinNumber = "12345678";
            vehicle.VehicleTypeID = 1;
            vehicle.VehicleTransmissionTypeID = 1;
            vehicle.VehicleSalePrice = 32012.99M;
            vehicle.VehicleMSRP = 35019.99M;
            vehicle.VehicleMileage = 120;
            vehicle.VehicleMakeYear = 2020;
            vehicle.VehicleMakeModelID = 1;
            vehicle.VehicleInteriorColorID = 3;
            vehicle.VehicleImageFileName = "Car Image";
            vehicle.VehicleExteriorColorID = 4;
            vehicle.VehicleDescription = "New Car";
            vehicle.VehicleBodyTypeID = 2;
            repo.AddNewVehicle(vehicle);
            Assert.AreEqual(1, vehicle.VehicleID);

            vehicle = new Vehicles();
            vehicle.VehicleVinNumber = "12345678";
            vehicle.VehicleTypeID = 1;
            vehicle.VehicleTransmissionTypeID = 2;
            vehicle.VehicleSalePrice = 54012.99M;
            vehicle.VehicleMSRP = 55019.99M;
            vehicle.VehicleMileage = 120;
            vehicle.VehicleMakeYear = 2021;
            vehicle.VehicleMakeModelID = 1;
            vehicle.VehicleInteriorColorID = 4;
            vehicle.VehicleImageFileName = "Car Image";
            vehicle.VehicleExteriorColorID = 5;
            vehicle.VehicleDescription = "A fancy car";
            vehicle.VehicleBodyTypeID = 3;
            
            repo.AddNewVehicle(vehicle);
            Assert.AreEqual(2, vehicle.VehicleID);

            vehicle = new Vehicles();
            vehicle.VehicleVinNumber = "12345678";
            vehicle.VehicleTypeID = 2;
            vehicle.VehicleTransmissionTypeID = 2;
            vehicle.VehicleSalePrice = 22012.99M;
            vehicle.VehicleMSRP = 24019.99M;
            vehicle.VehicleMileage = 120;
            vehicle.VehicleMakeYear = 2020;
            vehicle.VehicleMakeModelID = 1;
            vehicle.VehicleInteriorColorID = 4;
            vehicle.VehicleImageFileName = "Car Image";
            vehicle.VehicleExteriorColorID = 5;
            vehicle.VehicleDescription = "Another fancy car";
            vehicle.VehicleBodyTypeID = 3;
            
            repo.AddNewVehicle(vehicle);
            Assert.AreEqual(3, vehicle.VehicleID);
        }

        
        public void CanGetAllFeaturedVehicle()
        {

            var repo = new VehiclesDataRepository();
            Vehicles vehicle = repo.GetVehicleForEdit(2);
            vehicle.VehicleOnFeaturedList = true;
            repo.EditVehicle(vehicle);

            IEnumerable<VehicleShortSearch> list = repo.GetAllFeaturedVehicles();


            Assert.AreEqual("Honda", list.ElementAt(0).VehicleMakeDesc);
            Assert.AreEqual(2, list.ElementAt(0).VehicleID);
            Assert.AreEqual(54012.99M, list.ElementAt(0).VehicleSalePrice);
            Assert.AreEqual(1, list.Count());

        }

        public void CanPurchaseVehicle()
        {
            var repo = new SalesDataRepository();
            VehiclePurchaseData vpd = new VehiclePurchaseData();
            vpd.VehicleID = 1;
            vpd.StreetAddressLine1 = "1 Main Street";
            vpd.StreetAddressLine2 = "Apt 1";
            vpd.City = "Medina";
            vpd.ZipCode = "44251";
            vpd.StateID = "OH";

            vpd.UserID = "1111-1111-1111-1111";
            vpd.CustomerFullName = "Someone";
            vpd.CustomerEmailAddress = "my@my.com";
            vpd.CustomerPhoneNumber = "222-222-2222";
            vpd.PurchasePrice = 32000.99M;
            vpd.PurchaseTypeID = 1;


            repo.PurchaseVehicle(vpd);


            Assert.AreEqual(1,1);

        }

        
        public void CanSearchVehicle()
        {
            var repo = new VehiclesDataRepository();
            var parms = new VehicleSearchParameters();
            parms.QuickSearch = "2020";
            IEnumerable<VehicleLongSearch> vehicleList = repo.VehicleSearchResult(parms);

            Assert.AreEqual(1, vehicleList.ElementAt(0).VehicleID);
            Assert.AreEqual(1, vehicleList.Count());



        }
        
        public void CanSearchVehicle2()
        {
            var repo = new VehiclesDataRepository();
            var parms = new VehicleSearchParameters();

            parms.QuickSearch = "HO";
            parms.MinYear = 2021;
            

            IEnumerable<VehicleLongSearch> vehicleList = repo.VehicleSearchResult(parms);
                       
            
            Assert.AreEqual(2, vehicleList.ElementAt(0).VehicleID);
            Assert.AreEqual(1, vehicleList.Count());
        }



    }
}
