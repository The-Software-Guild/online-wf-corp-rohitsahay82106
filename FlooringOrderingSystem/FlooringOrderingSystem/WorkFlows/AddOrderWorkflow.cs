using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.WorkFlows
{
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order NewOrder = new Order();
            bool ValidateOrderDate = true;

            Console.Clear();
            Console.WriteLine("Add a new Order");
            Console.WriteLine("--------------------------");

            string _customerName = ConsoleIO.GetCustomerName();
            string _productType = ConsoleIO.GetProductType();
            decimal _area = ConsoleIO.GetArea();
            DateTime _orderDate = ConsoleIO.GetOrderDate(ValidateOrderDate);
            string _state = ConsoleIO.GetAbbrvStateCode(); 

            NewOrder.CustomerName = _customerName;
            NewOrder.ProductType = _productType;
            NewOrder.Area = _area;
            NewOrder.State = _state;
            NewOrder.OrderDate = _orderDate;

            AddOrderResponse _addOrderResponse = manager.AddNewOrder(NewOrder);

            if (!_addOrderResponse.Success)
            {
                Console.WriteLine("An error occurred during Edit request. Please contact IT...");
                Console.ReadKey();
                return;
            }

            ConsoleIO.DisplayOrder(_addOrderResponse.Order);

            string _userWantsToPlaceOrder;
            Console.WriteLine("Do you want to confirm and place the order? ");

            while(true)
            {
                Console.Write("Please enter Yes(Y) or No(N) : ");
                _userWantsToPlaceOrder = Console.ReadLine();
                if ((_userWantsToPlaceOrder == "Y")||(_userWantsToPlaceOrder=="N"))
                {
                    break;
                }
                Console.WriteLine("Invalid entry, please try again");
            }

            if ((_userWantsToPlaceOrder == "No") || (_userWantsToPlaceOrder == "N"))
            {
                Console.WriteLine("\n Order not saved. Thank You! ");
            }
            else
            {
                SaveOrderResponse _saveOrderResponse = manager.SaveOrder(_addOrderResponse.Order);
                if(_saveOrderResponse.Success)
                {
                    Console.WriteLine("\n Order was successfully saved."); 
                    Console.WriteLine($" Your Order number is { _saveOrderResponse.Order.OrderNumber}");
                    
                }
                else
                {
                    Console.WriteLine(" An error occurred. Please contact IT...");
                    Console.ReadKey();
                    return;
                }

            }

            








            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    }
}
