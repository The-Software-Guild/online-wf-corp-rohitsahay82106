using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class VehicleSearchParameters
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public short? MinYear { get; set; }
        public short? MaxYear { get; set; }
        public string QuickSearch { get; set; }
    }
}
