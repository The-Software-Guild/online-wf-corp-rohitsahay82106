using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class VehicleMakeModelSearch
    {
        public int VehicleMakeModelID { get; set; }
        public string VehicleMakeDesc { get; set; }
        public string VehicleModelDesc { get; set; }
        public DateTime VehicleMakeModelAddedDate { get; set; }
        public string UserID { get; set; }
    }
}
