using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class VehiclePurchaseData
    {
        public string StreetAddressLine1 { get; set; }
        public string StreetAddressLine2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string StateID { get; set; }

        public string CustomerFullName { get; set; }
        public string CustomerEmailAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }

        public int VehicleID { get; set; }
        public string UserID { get; set; }
        public decimal PurchasePrice { get; set; }
        public int PurchaseTypeID { get; set; }

        public int SaleID { get; set; }

    }
}
