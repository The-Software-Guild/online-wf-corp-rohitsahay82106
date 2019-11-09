using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.WorkFlows
{
    public class OrderDisplayWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Display all Orders for a date");
            Console.WriteLine("-------------------------------");

            DateTime _orderDate = ConsoleIO.GetOrderDate();

            DisplayAllOrdersResponse response = manager.Display(_orderDate);

            if (response.Success)
            {
                ConsoleIO.DisplayAllOrders(response.Orders);
            }
            else
            {
                Console.Write(" An error occurred: ");
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    }
}
