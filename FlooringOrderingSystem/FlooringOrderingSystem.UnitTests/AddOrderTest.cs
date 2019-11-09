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
    public class AddOrderTest
    {
        [Test]
        public void CanAddOrders()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order order = new Order()
            {
                OrderDate = new DateTime(2020,1,1),
                CustomerName = "Acme, Inc.",
                Area = 200,
                ProductType = "Laminate",
                State = "PA"
            };
            AddOrderResponse addOrderResponse = manager.AddNewOrder(order);

            Assert.IsTrue(addOrderResponse.Success);
            Assert.AreEqual(350, addOrderResponse.Order.MaterialCost);
            Assert.AreEqual(420, addOrderResponse.Order.LaborCost);
            Assert.AreEqual(51.98, addOrderResponse.Order.Tax);
            Assert.AreEqual(821.98, addOrderResponse.Order.Total);

            Response saveOrderResponse = manager.SaveOrder(addOrderResponse.Order);
            Assert.IsTrue(saveOrderResponse.Success);

            DisplayAllOrdersResponse responses = manager.Display(new DateTime(2020, 1, 1));
            Assert.IsNotNull(responses.Orders);
            Assert.IsTrue(responses.Success);





        }

        [TestCase("1/1/2020","Rohit Sahay","PA","Laminate",100,true)]
        [TestCase("1/1/2020", "Acme, Inc.", "PA", "Laminate", 3500, true)]
        [TestCase("1/1/2020", "Acme# Inc.", "PA", "Laminate", 3500, false)]
        [TestCase("1/1/2020", "Rohit Sahay", "FL", "Laminate", 200, false)]
        [TestCase("1/1/2020", "Rohit Sahay", "PA", "Granite", 200, false)]
        [TestCase("1/1/2020", "Rohit Sahay", "PA", "Laminate", 99, false)]
        public void CheckRulesAddOrders(DateTime OrderDate, string CustomerName, string StateAbbrv, string ProductType, decimal Area, bool ExpectedResult)
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order order = new Order()
            {
                OrderDate = OrderDate,
                CustomerName = CustomerName,
                Area = Area,
                ProductType = ProductType,
                State = StateAbbrv
            };
            AddOrderResponse addOrderResponse = manager.AddNewOrder(order);

            Assert.AreEqual(ExpectedResult, addOrderResponse.Success);

            if (addOrderResponse.Success)
            {
                Response saveOrderResponse = manager.SaveOrder(addOrderResponse.Order);
                Assert.IsTrue(saveOrderResponse.Success);

            }

            
        }
    }
}
