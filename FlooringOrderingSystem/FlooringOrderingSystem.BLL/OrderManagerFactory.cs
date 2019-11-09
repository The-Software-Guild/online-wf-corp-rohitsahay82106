using FlooringOrderingSystem.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            
            switch (mode)
            {
                case "Test":
                    return new OrderManager(new TestSystemOrders());
                case "Production":
                    return new OrderManager(new ProductionOrders());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
    
}
