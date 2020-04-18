using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class VehicleLongSearch
    {
        public short VehicleMakeYear { get; set; }
        public string VehicleMakeDesc { get; set; }
        public string VehicleModelDesc { get; set; }
        public string VehicleImageFileName { get; set; }
        public string VehicleBodyTypeDesc { get; set; }
        public string VehicleTransmissionTypeDesc { get; set; }
        public string VehicleTypeDesc { get; set; }
        public string VehicleVinNumber { get; set; }
        public decimal VehicleMSRP { get; set; }
        public decimal VehicleSalePrice { get; set; }
        public string VehicleDescription { get; set; }
        public string VehicleExteriorColorDesc { get; set; }
        public string VehicleInteriorColorDesc { get; set; }
        public int VehicleMileage { get; set; }
        public int VehicleID { get; set; }
    }
}
