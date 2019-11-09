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
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order OldOrder = new Order();
            bool ValidateOrderDate = true;

            Console.Clear();
            Console.WriteLine("Delete an Order");
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
            ConsoleIO.DisplayOrder(OldOrder);


            string _userWantsToDeleteOrder;
            Console.WriteLine("Do you want to delete this order?");
            
            while (true)
            {
                Console.Write("Please enter Yes(Y) or No(N) : ");
                _userWantsToDeleteOrder = Console.ReadLine();
                if ((_userWantsToDeleteOrder == "Y") || (_userWantsToDeleteOrder == "N"))
                {
                    break;
                }
                Console.WriteLine("Invalid entry, please try again");
            }

            if ((_userWantsToDeleteOrder == "No") || (_userWantsToDeleteOrder == "N"))
            {
                Console.WriteLine("\n Order not deleted. Thank You! ");
            }
            else
            {
                Response _deleteOrderResponse = manager.DeleteOrder(OldOrder);
                if (_deleteOrderResponse.Success)
                {
                    Console.WriteLine("\n Order was successfully deleted...");
                }
                else
                {
                    Console.WriteLine(" An error occurred during Edit request. Please contact IT...");
                    Console.ReadKey();
                    return;
                }
            }


            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    }
}
