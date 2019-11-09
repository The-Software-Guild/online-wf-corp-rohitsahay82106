using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.BLL.BusinessLogic;
using FlooringOrderingSystem.Data.ReferenceDataRepository;
using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem
{
    public class ConsoleIO
    {
        public static void DisplayAllOrders(List<Order> Orders)
        {

            string boundaryLine = ("|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|");
            string dataFormat = "|{0,-10} | {1,-8} | {2,-35} | {3,-20} | {4,-8:c} / {5,-20:c} | {6,-15} | {7,-15:c} | {8,-15:c} | {9,-15:0.00%} | {10,-15:c}| {11,-15:c} |";

                                    
            Console.WriteLine(boundaryLine);
            Console.WriteLine(dataFormat, "Order No.","State","Customer Name","Product Name", "Material","Labor Cost per sqft","Area in sqft","Material Cost","Labor Cost","Tax Rate","Total Tax","Total Cost");
            Console.WriteLine(boundaryLine);
                        
            foreach (Order order in Orders.OrderBy(e=> e.OrderNumber))
            {
                Console.WriteLine(dataFormat, order.OrderNumber, order.State, order.CustomerName, order.ProductType, order.CostPerSquareFoot, order.LaborCostPerSquareFoot, order.Area,order.MaterialCost, order.LaborCost, order.TaxRate/100, order.Tax,order.Total);
                
            }

            Console.WriteLine(boundaryLine);
            
        }

        public static void DisplayOrder(Order Order)
        {
            Console.WriteLine();

            string dataFormat = "{0,-30} : {1,-30}";
            if (Order.OrderNumber > 0)
            {
                
                Console.WriteLine(dataFormat, "Order No.", Order.OrderNumber);
            }
            Console.WriteLine(dataFormat,"Customer Name", Order.CustomerName);
            Console.WriteLine(dataFormat,"Product Type", Order.ProductType);
            Console.WriteLine(dataFormat, "Material Cost per sqft", $"{Order.CostPerSquareFoot:c}");
            Console.WriteLine(dataFormat,"Labor Cost per sqft", $"{Order.LaborCostPerSquareFoot:c}");
            Console.WriteLine(dataFormat, "Total Area in sqft",Order.Area);
            Console.WriteLine(dataFormat,"Material Cost",$"{Order.MaterialCost:c}");
            Console.WriteLine(dataFormat,"Labor Cost",$"{Order.LaborCost:c}");
            Console.WriteLine(dataFormat,"State", $"{Order.State}");
            Console.WriteLine(dataFormat,"Tax Rate",$"{Order.TaxRate/100:0.00%}");
            Console.WriteLine(dataFormat,"Tax",$"{Order.Tax:c}");
            Console.WriteLine(dataFormat,"Total Cost",$"{Order.Total:c}");
        }

        public static string GetProductType(bool Required = true, string currentValue = null)
        {
            ProductsManager _productsRepository = ProductsManagerFactory.Create();

            ProductsListResponse productsListResponse = _productsRepository.GetProductsList();

            if (!productsListResponse.Success)
            {
                Console.WriteLine(productsListResponse.Message);
                
                return productsListResponse.Message;
            }


            string boundaryLine = ("|----------------------------------------------------------------------|");
            string dataFormat = "|{0,-12} | {1,-20} | {2,-8:c} / {3,-20:c} |";

            Console.WriteLine();
            Console.WriteLine("  Product Catalogue");
            Console.WriteLine(boundaryLine);
            Console.WriteLine(dataFormat, "Serial No.", "Product Name", "Material", "Labor Cost per sqft");
            Console.WriteLine(boundaryLine);


            int serialno = 0;
            
            foreach (Products product in productsListResponse.ProductsList)
            {
                serialno += 1;
                Console.WriteLine(dataFormat,serialno,product.ProductType,product.CostPerSquareFoot,product.LaborCostPerSquareFoot);
                
            }

            Console.WriteLine(boundaryLine);

            int ChosenSerialNo = 0;
            while(true)
            {
                if (currentValue!= null)
                {
                    Console.Write($"\n Please enter the serial number of the desired product ({currentValue}) : ");
                }
                else
                {
                    Console.Write("\n Please enter the serial number of the desired product : ");
                }
                
                string userChoice = Console.ReadLine();

                if (int.TryParse(userChoice,out ChosenSerialNo))
                {
                    if ((ChosenSerialNo <= serialno) && (ChosenSerialNo>0))
                    {
                        break;
                    }
                }

                if (!Required)
                {
                    break;
                }

                Console.WriteLine("Invalid entry please try again..");
                
            }

            if (ChosenSerialNo == 0)
            {
                return currentValue;
            }
            
            Products p = productsListResponse.ProductsList.ElementAt(ChosenSerialNo - 1);
            return p.ProductType;

        }

        public static string GetCustomerName(bool Required = true, string currentValue = null)
        {
            while(true)
            {
                if (currentValue!=null)
                {
                    Console.Write($"\n Please enter Customer Name ({currentValue}): ");
                }
                else
                {
                    Console.Write("\n Please enter Customer Name: ");
                }
                
                string _customerName = Console.ReadLine();

                if (Required || _customerName.Length>0)
                {
                    DataValidation dataValidation = new DataValidation();
                    Response response = dataValidation.ValidateCustomerName(_customerName);
                    if (response.Success)
                    {
                        return _customerName;
                    }

                    Console.WriteLine($" {response.Message}");
                }

                if (!Required && _customerName.Length==0)
                {
                    return currentValue;
                }

                Console.WriteLine("Invalid entry, please try again..");
                
            }
            

        }

        public static decimal GetArea(bool Required = true, decimal currentValue = 0)
        {
            decimal _area = 0;
            while (true)
            {
                if (currentValue > 0 )
                {
                    Console.Write($"\n Please enter Area in sqft ({currentValue}) : ");
                }
                else
                {
                    Console.Write("\n Please enter Area in sqft : ");
                }
                
                string _areaString = Console.ReadLine();

                if (_areaString.Length>0)
                {
                    if (decimal.TryParse(_areaString, out _area))
                    {
                        DataValidation dataValidation = new DataValidation();
                        Response response = dataValidation.ValidateArea(_area);
                        if (response.Success)
                        {
                            return _area;
                        }

                        Console.WriteLine($" {response.Message}");
                    }
                }
                                
                else if (!Required)
                {
                   return currentValue;
                }

                Console.WriteLine(" Invalid entry, please try again..");
            }

        }
        
        
        public static DateTime GetOrderDate(bool ValidateOrderDate = false)
        {
            DateTime _date; 
            while (true)
            {
                Console.Write("\n Please enter Order Date (in MM/DD/YYYY format) : ");
                string _dateString = Console.ReadLine();
               
                if (DateTime.TryParse(_dateString,out _date))
                {
                    if(ValidateOrderDate)
                    {
                        DataValidation dataValidation = new DataValidation();
                        Response response = dataValidation.ValidateOrderDate(_date);
                        if (response.Success)
                        {
                            return _date;
                        }

                        Console.WriteLine(response.Message);
                    }
                    else
                    {
                        return _date;
                    }

                                        
                }

                Console.WriteLine("Invalid entry, please try again...");
            }

            
        }

        public static int GetOrderNumber()
        {
            int _orderNumber;
            while (true)
            {
                Console.Write("\n Please enter Order Number: ");
                string _orderNumberString = Console.ReadLine();

                if (int.TryParse(_orderNumberString, out _orderNumber))
                {
                    break;
                }

                Console.WriteLine("Invalid entry, please try again...");
            }

            return _orderNumber;
        }

        public static string GetAbbrvStateCode(bool Required = true, string currentValue = null)
        {
            while (true)
            {
                if(currentValue!=null)
                {
                    Console.Write($"\n Please enter State code({currentValue}): ");
                }
                else
                {
                    Console.Write("\n Please enter State code: ");
                }

                string _stateAbbrv = Console.ReadLine();

                if (_stateAbbrv.Length == 2)
                {

                    DataValidation dataValidation = new DataValidation();
                    Response response = dataValidation.ValidateStateCode(_stateAbbrv, out decimal TaxRate);
                    if (response.Success)
                    {
                        return _stateAbbrv;
                    }

                    Console.WriteLine(response.Message);
                }
                
                if (!Required)
                {
                    return currentValue;
                }

                Console.WriteLine("Invalid entry, please try again..");
            }


        }
    }
}
