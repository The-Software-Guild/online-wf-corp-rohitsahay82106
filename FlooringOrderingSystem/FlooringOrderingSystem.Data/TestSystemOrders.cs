using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Interfaces;
using FlooringOrderingSystem.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Data
{
    public class TestSystemOrders: IOrdersInventory
    {
        private static Order _order = new Order
        {
            OrderDate = new DateTime(2019,01,01),
            OrderNumber = 1,
            CustomerName = "Mr. X Men",
            State = "OH",
            TaxRate = 7.25M,
            ProductType = "Laminate",
            Area = 200,
            CostPerSquareFoot = 4.59M,
            LaborCostPerSquareFoot = 2.78M,
            MaterialCost = 200*4.59M,
            LaborCost = 200*2.78M,
            Tax = 200*(4.59M+2.78M)*7.25M/100,
            Total= 200 * (4.59M + 2.78M) * (1 + 7.25M / 100)
        };

        private static List<Order> OrderList = new List<Order>
        {
            _order

        };
        

        public Order LookUpOrder(DateTime OrderDate, int OrderNumber)
        {
            Order order = new Order();

            var _order = from o in OrderList
                        where o.OrderDate == OrderDate && o.OrderNumber == OrderNumber
                        select o;

            if (_order.Count()> 0)
            {
                order = (Order)_order.First();
            }
            
            return order;

        }

        public List<Order> LoadOrder(DateTime OrderDate)
        {
            List<Order> _orderList = new List<Order>();

            
            OrderList.OrderBy(c => c.OrderDate).ThenBy(t => t.OrderNumber);

            foreach(Order o in OrderList)
            {
                if (o.OrderDate == OrderDate)
                {
                    _orderList.Add(o);
                    
                }
                if (o.OrderDate >OrderDate)
                {
                    break;
                }
                
               
            }

            return _orderList;
        }

        public SaveOrderResponse SaveOrder(Order Order)
        {
            SaveOrderResponse response = new SaveOrderResponse();

            OrderList.OrderBy(c => c.OrderDate).ThenBy(t => t.OrderNumber);    
                        
            int _index =0, _highestOrderNumber = 0;

            foreach(Order o in OrderList)
            {
                
                if ((o.OrderDate == Order.OrderDate)&&(o.OrderNumber == Order.OrderNumber))
                {
                    OrderList.RemoveAt(_index);
                    
                    break;
                }

                if(Order.OrderDate == o.OrderDate)
                {
                    _highestOrderNumber = o.OrderNumber;
                }

                _index++;
            }

            Order.OrderNumber = _highestOrderNumber + 1;
            
            
            OrderList.Add(Order);

            response.Order = Order;
            response.Success = true;
            response.Message = "Saved successfully";
            return response;

        }

        public Response DeleteOrder(Order Order)
        {
            Response response = new Response();

            int _index = 0;
            foreach (Order o in OrderList)
            {

                if ((o.OrderDate == Order.OrderDate) && (o.OrderNumber == Order.OrderNumber))
                {
                    OrderList.RemoveAt(_index);
                    break;
                }

                _index++;
            }

            response.Success = true;
            response.Message = "Delete successfull";
            return response;

        }
    }
}
