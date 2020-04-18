using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class VehicleShortSearch
    {
        public short VehicleMakeYear { get; set; }
        public string VehicleMakeDesc { get; set; }
        public string VehicleModelDesc { get; set; }
        public string VehicleImageFileName { get; set; }
        public decimal VehicleSalePrice { get; set; }
        public int VehicleID { get; set; }

    }
}
