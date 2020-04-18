using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Sales
    {
        public int SaleID { get; set; }
        public int CustomerID { get; set; }
        public int VehicleID { get; set; }
        public string UserID { get; set; }
        public decimal PurchasePrice { get; set; }
        public int PurchaseTypeID { get; set; }
        public DateTime SaleDate { get; set; }

    }
}
