using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class InventoryReport
    {
        public short VehicleMakeYear { get; set; }
        public string VehicleMakeDesc { get; set; }
        public string VehicleModelDesc { get; set; }
        public int VehicleCount { get; set; }
        public decimal VehicleStockValue { get; set; }

    }
}
