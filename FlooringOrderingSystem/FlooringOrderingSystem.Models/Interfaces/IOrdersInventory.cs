using System;
using FlooringOrderingSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Models.Responses;

namespace FlooringOrderingSystem.Models.Interfaces
{
    public interface IOrdersInventory
    {
        Order LookUpOrder(DateTime OrderDate, int OrderNumber);
        DisplayAllOrdersResponse LoadOrder(DateTime OrderDate);
        SaveOrderResponse SaveOrder(Order Order);
        Response DeleteOrder(Order Order);

    }
}
