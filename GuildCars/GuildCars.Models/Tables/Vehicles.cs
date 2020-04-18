using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Vehicles
    {
        public int VehicleID { get; set; }
        public string VehicleVinNumber { get; set; }
        public int VehicleMakeModelID { get; set; }
        public short VehicleMakeYear { get; set; }
        public int VehicleTypeID { get; set; }
        public int VehicleTransmissionTypeID { get; set; }
        public int VehicleBodyTypeID { get; set; }
        public int VehicleExteriorColorID { get; set; }
        public int VehicleInteriorColorID { get; set; }
        public int VehicleMileage { get; set; }
        public decimal VehicleMSRP { get; set; }
        public decimal VehicleSalePrice { get; set; }
        public string VehicleDescription { get; set; }
        public string VehicleImageFileName { get; set; }
        public bool VehicleOnFeaturedList { get; set; }
        public DateTime VehicleAddedToInventoryDate { get; set; }
        public DateTime VehicleRemovedFromInventoryDate { get; set; }

    }
}
