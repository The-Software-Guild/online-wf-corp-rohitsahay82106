using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class VehicleMakeModel
    {
        public int VehicleMakeModelID { get; set; }
        public int VehicleMakeID { get; set; }
        public string VehicleModelDesc { get; set; }
        public DateTime VehicleMakeModelAddedDate { get; set; }
        public string UserID { get; set; }
    }
}
