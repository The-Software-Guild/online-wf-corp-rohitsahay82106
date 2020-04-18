using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class VehicleMake
    {
        public int VehicleMakeID { get; set; }
        public string VehicleMakeDesc { get; set; }
        public DateTime VehicleMakeAddedDate { get; set; }
        public string UserID { get; set; }
    }
}
