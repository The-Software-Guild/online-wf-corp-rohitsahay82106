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
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order OldOrder = new Order();
            bool ValidateOrderDate = true;


            Console.Clear();
            Console.WriteLine("Update an Order");
            Console.WriteLine("--------------------------");

            DateTime _orderDate = ConsoleIO.GetOrderDate(ValidateOrderDate);
            int _orderNumber = ConsoleIO.GetOrderNumber();

            OrderLookUpResponse orderLookUpResponse = manager.OrderLookUp(_orderDate, _orderNumber);
            if (!orderLookUpResponse.Success)
            {
                Console.WriteLine(" No Orders found, please check your receipt and try again..");
                Console.WriteLine(" Press any key to return to main Menu");
                Console.ReadKey();
                return;
            }

            OldOrder = orderLookUpResponse.Order;

            string _newCustomerName = ConsoleIO.GetCustomerName(false, OldOrder.CustomerName);
            string _newProductType = ConsoleIO.GetProductType(false, OldOrder.ProductType);
            string _newState = ConsoleIO.GetAbbrvStateCode(false, OldOrder.State);
            decimal _newArea = ConsoleIO.GetArea(false, OldOrder.Area);

            Order UpdatedOrder = new Order();
            UpdatedOrder.OrderDate = OldOrder.OrderDate;
            UpdatedOrder.OrderNumber = OldOrder.OrderNumber;
            UpdatedOrder.CustomerName = _newCustomerName;
            UpdatedOrder.ProductType = _newProductType;
            UpdatedOrder.State = _newState;
            UpdatedOrder.Area = _newArea;

            EditResponse editResponse = manager.UpdateOrder(OldOrder, UpdatedOrder);

            if (!editResponse.Success)
            {
                Console.WriteLine("An error occurred during Edit request. Please contact IT...");
                Console.ReadKey();
                return;
            }

            ConsoleIO.DisplayOrder(editResponse.UpdatedOrder);

            string _userWantsToPlaceOrder;
            Console.WriteLine("Do you want to confirm and place the order? ");

            while (true)
            {
                Console.Write("Please enter Yes(Y) or No(N) : ");
                _userWantsToPlaceOrder = Console.ReadLine();
                if ((_userWantsToPlaceOrder == "Y") || (_userWantsToPlaceOrder == "N"))
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
                SaveOrderResponse _saveOrderResponse = manager.SaveOrder(editResponse.UpdatedOrder);
                if (_saveOrderResponse.Success)
                {
                    Console.WriteLine("\n Order was successfully saved.");
                    Console.WriteLine($" Your Order number is {_saveOrderResponse.Order.OrderNumber}");
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
