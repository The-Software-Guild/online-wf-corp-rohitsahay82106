using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Responses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.UnitTests
{
    [TestFixture]
    public class DeleteOrder
    {
                         
            Order NewOrder = new Order()
            {
                OrderDate = new DateTime(2020, 1, 1),
                CustomerName = "Rohit Sahay",
                Area = 200,
                ProductType = "Laminate",
                State = "PA"
            };
        
        

        [Test]
        public void CanDeleteOrders()
        {
            OrderManager manager = OrderManagerFactory.Create();
            AddOrderResponse addOrderResponse = manager.AddNewOrder(NewOrder);
            Response saveOrderResponse = manager.SaveOrder(addOrderResponse.Order);

                                          
            OrderLookUpResponse orderLookUpResponse = manager.OrderLookUp(new DateTime(2020,1,1), 1);
            Response response = manager.DeleteOrder(orderLookUpResponse.Order);
            Assert.IsTrue(response.Success);

        }
    }
}
