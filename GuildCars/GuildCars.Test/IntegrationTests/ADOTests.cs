using GuildCars.Data.Repository_Prod;
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
    public class ADOTests
    {
        [Test]
        public void CanGetTransmission()
        {
            int id = 1;
            var repo = new SupportingDataRepository();
            VehicleTransmissionType Type = repo.GetVehicleTransmissionType(id);

            Assert.AreEqual("Manual", Type.VehicleTransmissionTypeDesc);
        }

        [Test]
        public void CanGetAllTransmission()
        {
            
            var repo = new SupportingDataRepository();
            IEnumerable <VehicleTransmissionType> list = repo.GetAllVehicleTransmissionType();


            Assert.AreEqual("Manual", list.ElementAt(0).VehicleTransmissionTypeDesc);
                
        }

        [Test]
        public void CanGetAllStates()
        {

            var repo = new SupportingDataRepository();
            IEnumerable<States> list = repo.GetAllStates();


            Assert.AreEqual("OH", list.ElementAt(5).StateID);
            Assert.AreEqual("Ohio", list.ElementAt(5).StateName);
            Assert.AreEqual("IN", list.ElementAt(1).StateID);
            Assert.AreEqual("Indiana", list.ElementAt(1).StateName);
            Assert.AreEqual("WV", list.ElementAt(7).StateID);
        }

        [Test]
        public void CanGetAllVehicleType()
        {

            var repo = new SupportingDataRepository();
            IEnumerable<VehicleType> list = repo.GetAllVehicleType();


            Assert.AreEqual("New", list.ElementAt(0).VehicleTypeDesc);
            Assert.AreEqual("Used", list.ElementAt(1).VehicleTypeDesc);

        }
    }
}
