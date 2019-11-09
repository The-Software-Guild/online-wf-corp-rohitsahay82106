using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Models.Responses
{
    public class DisplayAllOrdersResponse : Response
    {
        
        public List<Order> Orders = new List<Order>();

    }
}
