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
    public class EditOrderTests
    {
        [Test]
        public void CanEditOrders()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order OldOrder = new Order()
            {
                OrderDate =  new DateTime(2020,1,1),
                OrderNumber = 1,
                CustomerName = "Acme, Inc.",
                Area = 200,
                ProductType = "Laminate",
                State = "PA",
                TaxRate = 6.75M,
                CostPerSquareFoot = 1.75M,
                LaborCostPerSquareFoot = 2.10M,
                MaterialCost = 350,
                LaborCost = 420,
                Tax = 51.98M,
                Total = 821.98M

            };

            Order UpdatedOrder = new Order()
            {
                OrderDate = new DateTime(2020,1,1),
                OrderNumber = 1,
                CustomerName = "Rohit Sahay, Inc.",
                Area = 200,
                ProductType = "Laminate",
                State = "PA",
                TaxRate = 6.75M,
                CostPerSquareFoot = 1.75M,
                LaborCostPerSquareFoot = 2.10M,
                MaterialCost = 350,
                LaborCost = 420,
                Tax = 51.98M,
                Total = 821.98M
            };

            EditResponse editResponse = manager.UpdateOrder(OldOrder, UpdatedOrder);

            Assert.IsTrue(editResponse.Success);
            Assert.AreEqual(OldOrder.Total, editResponse.UpdatedOrder.Total);
            Assert.AreEqual(OldOrder.CostPerSquareFoot, editResponse.UpdatedOrder.CostPerSquareFoot);
            Assert.AreEqual(OldOrder.LaborCostPerSquareFoot, editResponse.UpdatedOrder.LaborCostPerSquareFoot);
            Assert.AreEqual(OldOrder.TaxRate, editResponse.UpdatedOrder.TaxRate);
            Assert.AreEqual("Rohit Sahay, Inc.", editResponse.UpdatedOrder.CustomerName);
        }

        [TestCase("Rohit Sahay#", "OH", "Laminate",200, 1.75, 2.10, 6.25, 818.13,false)]
        [TestCase("Rohit, Sahay", "IN", "Laminate", 200, 1.75, 2.10, 6.00, 816.2,true)]
        [TestCase("Rohit Sahay, Inc.", "IN", "Carpet", 100, 2.25, 2.10, 6.00, 461.1,true)]
        [TestCase("Rohit Sahay", "FL", "Laminate", 200, 1.75, 2.10, 6.00, 816.2, false)]
        [TestCase("Rohit Sahay", "IN", "Granite", 100, 2.25, 2.10, 6.00, 461.1, false)]
        [TestCase("Rohit Sahay", "IN", "Carpet", 99, 2.25, 2.10, 6.00, 456.49, false)]
        public void CheckMultipleEdits(string CustomerName, string StateAbbrv, string ProductType, decimal Area, decimal CostPerSquareFoot, decimal LaborCostPerSquareFoot, decimal TaxRate,decimal Total,bool ExpectedResult)
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order OldOrder = new Order()
            {
                OrderDate = new DateTime(2020,1,1), 
                OrderNumber = 1,
                CustomerName = "Rohit Sahay",
                Area = 200,
                ProductType = "Laminate",
                State = "PA",
                TaxRate = 6.75M,
                CostPerSquareFoot = 1.75M,
                LaborCostPerSquareFoot = 2.10M,
                MaterialCost = 350,
                LaborCost = 420,
                Tax = 51.975M,
                Total = 821.975M

            };

            Order UpdatedOrder = new Order()
            {
                OrderDate = new DateTime(2020,1,1), 
                OrderNumber = 1,
                CustomerName = CustomerName,
                Area = Area,
                ProductType = ProductType,
                State = StateAbbrv,
                TaxRate = 6.75M,
                CostPerSquareFoot = 1.75M,
                LaborCostPerSquareFoot = 2.10M,
                MaterialCost = 350,
                LaborCost = 420,
                Tax = 51.98M,
                Total = 821.98M
            };

            EditResponse editResponse = manager.UpdateOrder(OldOrder, UpdatedOrder);

            Assert.AreEqual(ExpectedResult, editResponse.Success);
            if (editResponse.Success)
            {
                Assert.AreEqual(Total, editResponse.UpdatedOrder.Total);
                Assert.AreEqual(CostPerSquareFoot, editResponse.UpdatedOrder.CostPerSquareFoot);
                Assert.AreEqual(LaborCostPerSquareFoot, editResponse.UpdatedOrder.LaborCostPerSquareFoot);
                Assert.AreEqual(TaxRate, editResponse.UpdatedOrder.TaxRate);
                Assert.AreEqual(CustomerName, editResponse.UpdatedOrder.CustomerName);
            }
            
        }

    }
}
