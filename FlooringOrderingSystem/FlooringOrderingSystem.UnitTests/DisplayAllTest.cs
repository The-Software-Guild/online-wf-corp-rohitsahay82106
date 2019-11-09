using FlooringOrderingSystem.Data;
using FlooringOrderingSystem.BLL;
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
    public class DisplayAllTest
    {
        [Test]
        public void CanDisplayOrders()
        {
            
            OrderManager manager = OrderManagerFactory.Create();
            DisplayAllOrdersResponse responses = manager.Display(new DateTime(2019,1,1));
            Assert.IsNotNull(responses.Orders);
            Assert.IsTrue(responses.Success);
            
        }
        [Test]
        public void CanDetectInvalidOrderDate()
        {
            OrderManager manager = OrderManagerFactory.Create();
            DisplayAllOrdersResponse responses = manager.Display(new DateTime(2019,1,19 ));
            Assert.IsEmpty(responses.Orders);
            Assert.IsFalse(responses.Success);

        }
    }
}
