using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Interfaces;
using FlooringOrderingSystem.Models.Responses;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Data
{
    public class ProductionOrders: IOrdersInventory
    {
        private readonly string FolderPath = @"..\..\..\FlooringOrderingSystem.Data\OrdersList";

        


        public Order LookUpOrder(DateTime OrderDate, int OrderNumber)
        {
            Order order = null;
            bool _orderFound = false;

            bool OrderFileExists = CheckOrderFileExist(OrderDate, out string filepath);
            if (!OrderFileExists)
            {
                return null;
            }

            using (StreamReader reader = new StreamReader(filepath))
            {
                string line = reader.ReadLine();
                while (((line = reader.ReadLine()) != null) && (!_orderFound))
                {
                    order = BuildOrderFromLine(line, OrderDate);
                                        
                    if (order.OrderNumber == OrderNumber)
                    {
                        _orderFound = true;
                    }

                }

            }

            
            if (_orderFound)
            {
                return order;
            }
            else
            {
                return null;
            }

                      
           
        }

        public List<Order> LoadOrder(DateTime OrderDate)
        {
            List<Order> orderList = new List<Order>();
                        
            bool OrderFileExists = CheckOrderFileExist(OrderDate, out string filepath);
            if (!OrderFileExists)
            {

                return orderList;

            }

            using (StreamReader reader = new StreamReader(filepath))
            {
                string line = reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    Order order = BuildOrderFromLine(line, OrderDate);
                    orderList.Add(order);
                                        
                }

            }

            return orderList;
            
        }

        public SaveOrderResponse SaveOrder(Order Order)
        {
            SaveOrderResponse response = new SaveOrderResponse();

            List<string> FileLines = new List<string>();
            string newline;
            bool _orderFound = false;
            int _highestOrderNumber = 0;


            bool OrderFileExists = CheckOrderFileExist(Order.OrderDate, out string filepath);
            if (!OrderFileExists)
            {
                newline = BuildFileHeaderLine();
                FileLines.Add(newline);

                Order.OrderNumber = 1;  //assign 1 to the order number since it's the first one for the order date
                newline = BuildFileLineFromOrder(Order);
                FileLines.Add(newline);

                File.WriteAllLines(filepath, FileLines);
                response.Success = true;
                response.Message = "Order saved";
                response.Order = Order;

                return response;
            }


            using (StreamReader reader = new StreamReader(filepath))
            {
                 string line = reader.ReadLine();
                newline = BuildFileHeaderLine();
                FileLines.Add(newline);

                while ((line = reader.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');
                    if (Order.OrderNumber.ToString() == columns[0])
                    { 
                        _orderFound = true;
                        columns[1] = RemoveCommafromData(Order.CustomerName);
                        columns[2] = Order.State;
                        columns[3] = Order.TaxRate.ToString();
                        columns[4] = Order.ProductType;
                        columns[5] = Order.Area.ToString();
                        columns[6] = Order.CostPerSquareFoot.ToString();
                        columns[7] = Order.LaborCostPerSquareFoot.ToString();
                        columns[8] = Order.MaterialCost.ToString();
                        columns[9] = Order.LaborCost.ToString();
                        columns[10] = Order.Tax.ToString();
                        columns[11] = Order.Total.ToString();

                    }

                    _highestOrderNumber = int.Parse(columns[0]);
                    newline = string.Join(",", columns);

                    FileLines.Add(newline);

                }

            }

            if (!_orderFound)
            {
                Order.OrderNumber = _highestOrderNumber+1;
                newline = BuildFileLineFromOrder(Order);
                
                FileLines.Add(newline);

            }

            File.WriteAllLines(filepath, FileLines);

            response.Success = true;
            response.Message = "Order saved";
            response.Order = Order;

            return response;
        }

        public Response DeleteOrder(Order Order)
        {
            Response response = new Response();

            List<string> FileLines = new List<string>();
            string newline;
            bool _orderFound = false;

            bool OrderFileExists = CheckOrderFileExist(Order.OrderDate, out string filepath);
            if (!OrderFileExists)
            {
                response.Success = false;
                response.Message = "Order not found";
                return response;
            }

            using (StreamReader reader = new StreamReader(filepath))
            {
                string line = reader.ReadLine();
                newline = BuildFileHeaderLine();
                FileLines.Add(newline);

                while ((line = reader.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');
                    if (Order.OrderNumber.ToString() == columns[0])
                    {
                        _orderFound = true;
                    }
                    else
                    {
                        newline = string.Join(",", columns);
                        FileLines.Add(newline);

                    }



                }

            }

            if (!_orderFound)
            {
                response.Success = false;
                response.Message = "Order not Found";
                return response;
            }


            File.WriteAllLines(filepath, FileLines);
            response.Success = true;
            response.Message = "Order Deleted successfully";
            return response;
        }

        private bool CheckOrderFileExist(DateTime OrderDate, out string Filepath)
        {
            bool OrderFileExists = false;
            string _month = OrderDate.Month.ToString();
            if (OrderDate.Month < 10)
            {
                _month = "0" + OrderDate.Month;
            }
            string _day = OrderDate.Day.ToString();
            if (OrderDate.Day < 10)
            {
                _day = "0" + OrderDate.Day;
            }

            string FileName = "Orders_" + _month + _day + OrderDate.Year + ".txt";


            string[] _filepath = Directory.GetFiles(FolderPath, FileName);
            

            if (_filepath.Count() > 0)
            {

                OrderFileExists = true;
                Filepath = _filepath[0];
            }
            else
            {
                Filepath = FolderPath + "\\" + FileName;
            }
                    
                        
            return OrderFileExists;


        }

        private string BuildFileLineFromOrder(Order Order)
        {
            string _customerName = RemoveCommafromData(Order.CustomerName);

            string newline = Order.OrderNumber.ToString() + "," +
                            _customerName + "," +
                            Order.State + "," +
                            Order.TaxRate.ToString() + "," +
                            Order.ProductType + "," +
                            Order.Area.ToString() + "," +
                            Order.CostPerSquareFoot.ToString() + "," +
                            Order.LaborCostPerSquareFoot.ToString() + "," +
                            Order.MaterialCost.ToString() + "," +
                            Order.LaborCost.ToString() + "," +
                            Order.Tax.ToString() + "," +
                            Order.Total.ToString();
            return newline;
        }

        private string BuildFileHeaderLine()
        {
            string newline = "OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total";
            return newline;
        }

        private string RemoveCommafromData(string input)
        {
            string output;

            output = input.Replace(",", "_");

            return output;
        }

        private string AddCommaintheData(string input)
        {
            string output;

            output = input.Replace("_", ",");

            return output;
        }

        private Order BuildOrderFromLine(string line, DateTime OrderDate)
        {
            Order order = new Order();

            string[] columns = line.Split(',');
            order.OrderNumber = int.Parse(columns[0]);
            order.OrderDate = OrderDate;
            order.CustomerName = AddCommaintheData(columns[1]);
            order.State = columns[2];
            order.TaxRate = decimal.Parse(columns[3]);
            order.ProductType = columns[4];
            order.Area = decimal.Parse(columns[5]);
            order.CostPerSquareFoot = decimal.Parse(columns[6]);
            order.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
            order.MaterialCost = decimal.Parse(columns[8]);
            order.LaborCost = decimal.Parse(columns[9]);
            order.Tax = decimal.Parse(columns[10]);
            order.Total = decimal.Parse(columns[11]);



            return order;

        }

    }
}
