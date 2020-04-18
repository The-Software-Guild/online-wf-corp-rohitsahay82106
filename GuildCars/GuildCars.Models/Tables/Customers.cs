using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Customers
    {
        public int CustomerID { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerEmailAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public int CustomerAddressID { get; set; }

    }
}
