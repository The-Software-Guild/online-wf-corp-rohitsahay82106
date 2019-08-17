using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();
            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5();
            //Exercise6();
            //Exercise7();
            //Exercise8();
            //Exercise9();
            //Exercise10();
            //Exercise11();
            //Exercise12();
            //Exercise13();      
            //Exercise14();
            //Exercise15();
            //Exercise16();
            //Exercise17();
            //Exercise18();
            //Exercise19();
            //Exercise20();
            //Exercise21();  
            //Exercise22();
            //Exercise23(); 
            //Exercise24();
            //Exercise25();
            //Exercise26();
            //Exercise27();  
            //Exercise28();
            //Exercise29();
            //Exercise30();
            //Exercise31();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            List<Product> products = DataLoader.LoadProducts();
            var OutOfStocks = from product in products
                              where product.UnitsInStock == 0
                              select product;
            PrintProductInformation(OutOfStocks);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            List<Product> products = DataLoader.LoadProducts();
            var OutOfStocks = from product in products
                              where ((product.UnitsInStock > 0) && (product.UnitPrice > 3)) 
                              select product;
            PrintProductInformation(OutOfStocks);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            List<Customer> customers = DataLoader.LoadCustomers();
            var WA_Customers = from customer in customers
                               where customer.Region == "WA"
                               select customer;

            PrintCustomerInformation(WA_Customers);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            List<Product> products = DataLoader.LoadProducts();
            var ProductNames = from product in products
                               select new { product.ProductName };
            Console.WriteLine("Product Name");
            foreach(var p in ProductNames)
            {
                Console.WriteLine(p.ProductName);
            }
            
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            List<Product> products = DataLoader.LoadProducts();
            var QuoteProductList = from product in products
                                   select new { product.ProductID,
                                                product.ProductName,
                                                product.Category,
                                                QuotePrice = ((product.UnitPrice*125)/100),
                                                product.UnitsInStock };
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in QuoteProductList)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.QuotePrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            List<Product> products = DataLoader.LoadProducts();
            var ProductInCaps = from product in products
                                select new
                                {
                                    CAPS_Name = (product.ProductName.ToString()).ToUpper(),
                                    CAPS_Category = (product.Category.ToString()).ToUpper()
                                   };
            string line = "{0,-35} {1,-15}";
            Console.WriteLine(line, "Product Name", "Category");
            Console.WriteLine("==============================================================================");

            foreach (var product in ProductInCaps)
            {
                Console.WriteLine(line, product.CAPS_Name, product.CAPS_Category); 
                    
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            List<Product> products = DataLoader.LoadProducts();
            var NewProductList = from product in products
                                   select new
                                   {
                                       product.ProductID,
                                       product.ProductName,
                                       product.Category,
                                       product.UnitPrice,
                                       product.UnitsInStock,
                                       ReOrder = product.UnitsInStock < 3 ? "Yes":"No"
                                   };
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,8} {5,4}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock","ReOrder?");
            Console.WriteLine("========================================================================================");

            foreach (var product in NewProductList)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock, product.ReOrder);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            List<Product> products = DataLoader.LoadProducts();
            var NewProductList = from product in products
                                 select new
                                 {
                                     product.ProductID,
                                     product.ProductName,
                                     product.Category,
                                     product.UnitPrice,
                                     product.UnitsInStock,
                                     StockValue = "$" + Math.Round(product.UnitsInStock*product.UnitPrice,2)
                                 };
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,10} {5,10}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "  Stock Value");
            Console.WriteLine("========================================================================================");

            foreach (var product in NewProductList)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock, product.StockValue);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            int[] Numbers = DataLoader.NumbersA;
            var EvenNumber = from number in Numbers
                             where number % 2 == 0
                             select number;
            Console.WriteLine("List of even numbers in NumbersA array are: {0}", string.Join(",",EvenNumber));
            Console.WriteLine();
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var CustomerOrder500orless = (from customer in customers
                                         from order in customer.Orders
                                         where order.Total < 500
                                         select customer).Distinct();



            PrintCustomerInformation(CustomerOrder500orless);


        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            int[] numbers = DataLoader.NumbersC;
            var first3odd = (from number in numbers
                             where number % 2 == 1
                             select number).Take(3);
            Console.WriteLine("First three odd numbers in NumbersC array are: {0}", string.Join(",", first3odd));
            Console.WriteLine();
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            int[] Numbers = DataLoader.NumbersB;
            var ExceptFirst3 = (from number in Numbers
                                select number).Skip(3);
            Console.WriteLine("Except first 3, these are the numbers in the array NumbersB: {0}", string.Join(",", ExceptFirst3));
            Console.WriteLine();
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var WACustomersRecentOrder = from c in customers
                                         where c.Region =="WA"
                                         select new
                                         {
                                                Name = c.CompanyName,
                                                state = c.Region,
                                                order = (from o in c.Orders
                                                         orderby o.OrderDate
                                                         select o).Last()
                                         };

            var NoDups_WACustomerRecentOrder = (from l in WACustomersRecentOrder
                                               select l).Distinct();

            string line = "{0,-40} {1,-20} {2,-30} {3,10}";
            Console.WriteLine(line, "Company Name", "Latest Order ID", "Latest Order Date", "Latest Order Total");
           
            Console.WriteLine("=========================================================================================================================");

            foreach (var x in NoDups_WACustomerRecentOrder)
            {
                Console.WriteLine(line, x.Name, x.order.OrderID, x.order.OrderDate, x.order.Total);
            }

            Console.WriteLine();   
            
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            int[] Numbers = DataLoader.NumbersC;
            var LessThan6 = (from number in Numbers
                             select number).TakeWhile(x => x < 6);
                            

            Console.WriteLine("Here are the numbers that appear before a number is >=6 : {0}", string.Join(",", LessThan6));
            Console.WriteLine();
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            int[] Numbers = DataLoader.NumbersC;
            var List1= (from number in Numbers
                      select number).SkipWhile(x => x % 3 != 0);
            var Skip1stList1 = (from number in List1
                         select number).Skip(1);

            Console.WriteLine("Here are the numbers that appear before a number is >=6 : {0}", string.Join(",", Skip1stList1));
            Console.WriteLine();
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            List<Product> products = DataLoader.LoadProducts();
            var SortedProducts = from p in products
                                 orderby p.ProductName ascending
                                 select p;
            PrintProductInformation(SortedProducts);
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            List<Product> products = DataLoader.LoadProducts();
            var SortedProducts = from p in products
                                 orderby p.UnitsInStock descending
                                 select p;
            PrintProductInformation(SortedProducts);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            List<Product> products = DataLoader.LoadProducts();
            var SortedProducts = from p in products
                                 orderby p.Category ascending,p.UnitPrice descending
                                 select p;

            PrintProductInformation(SortedProducts);
            
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            int[] numbers = DataLoader.NumbersB;
            var SortedNumbers = (from n in numbers
                                 select n).Reverse();
            Console.WriteLine("Numbers in NumbersB array in reverse order: {0}", string.Join(",", SortedNumbers));

        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            List<Product> products = DataLoader.LoadProducts();
            var GroupedProducts = from p in products
                                   group p.ProductName by p.Category into g
                                   select new { Category = g.Key, Products = g.ToList() };
            foreach(var x in GroupedProducts)
            {
                Console.WriteLine(x.Category);
                foreach(var y in x.Products)
                {
                    Console.WriteLine("   {0}",y);
                }
                Console.WriteLine();
               
            }

         
                                  
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        
        static void Exercise21()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var FlatOutCustomerTbl =    from c in customers
                                        from o in c.Orders
                                        select new
                                            {
                                                c.CompanyName,
                                                o.OrderDate.Year,
                                                o.OrderDate.Month,
                                                o.OrderDate.Day,
                                                o.Total
                                            };

            var SortedCustomerTbl = from a in FlatOutCustomerTbl
                                    orderby a.CompanyName, a.Year, a.Month
                                    select a;

            var TotalByMonth = from l in SortedCustomerTbl
                               select new
                                    {
                                        Name = l.CompanyName,

                                        year = l.Year,

                                        month = l.Month,

                                        Total = (from k in SortedCustomerTbl
                                                 where (k.Month == l.Month && k.Year == l.Year && k.CompanyName == l.CompanyName)
                                                 select k.Total).Sum()
                                     };

            var NoDupsTotal = TotalByMonth.Distinct();

            var prevName = "name";
            var prevYear = 0;

            foreach(var f in NoDupsTotal)
            {
                if (prevName != f.Name)
                {
                    prevName = f.Name;
                    prevYear = 0;
                    Console.WriteLine(f.Name);
                }
                if (prevYear != f.year)
                {
                    prevYear = f.year;
                    Console.WriteLine(f.year);

                }
                    Console.WriteLine("   {0,4} -  ${1}", f.month, f.Total);
            }
             

        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            List<Product> products = DataLoader.LoadProducts();
            var UniqueCategories = (from p in products
                                    select p.Category).Distinct();

            foreach(var x in UniqueCategories)
            {
                Console.WriteLine(x);
            }


        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            List<Product> products = DataLoader.LoadProducts();
            var If789Exists = from p in products
                              where p.ProductID == 789
                              select p; 
            if ((If789Exists == null )||(If789Exists.Count() == 0))
            {
                Console.WriteLine("product 789 does not exists....");
            }
            else
            {
                Console.WriteLine("product 789 exists");
            }
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            List<Product> products = DataLoader.LoadProducts();
            var list1 = (from p in products
                         where p.UnitsInStock == 0
                         select p.Category).Distinct();

           
            Console.WriteLine("List of Product Categories with at least one products out of stock are:");
            foreach (var x in list1)
            {
                Console.WriteLine(x);
            }


        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            List<Product> products = DataLoader.LoadProducts();
            var list1 = (from p in products
                         where p.UnitsInStock == 0
                         select p.Category).Distinct();

            var list2 = (from p in products
                        select p.Category).Distinct();

            var list3 = list2.Except(list1);

            Console.WriteLine("List of Product Categories with no products out of stock are:");
            foreach (var x in list3)
            {
                Console.WriteLine(x);
            }
            

            
            
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            int[] numbers = DataLoader.NumbersA;
            var OddNumbers = (from n in numbers
                              where n % 2 == 1
                              select n).Count();
            Console.WriteLine("No. of odd numbers in NumbersA array is {0}", OddNumbers);





        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            List<Customer> customers = DataLoader.LoadCustomers();
            var list1 = from c in customers
                        select new { cid = c.CustomerID, count = (c.Orders).Count() };

            foreach(var x in list1)
            {
                Console.WriteLine("Customer ID {0} has {1} orders..",x.cid,x.count);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            List<Product> products = DataLoader.LoadProducts();
            var list1 = from p in products
                        group p.ProductID by p.Category into g
                        select new { Category = g.Key, Count = g.ToList().Count() };
            string line = "{0,-30} {1,5}";
            Console.WriteLine(line, "Category", "Count");
            Console.WriteLine("=====================================================");

            foreach(var x in list1)
            {
                Console.WriteLine(line, x.Category, x.Count);    
            }
            Console.WriteLine("=====================================================");
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            List<Product> products = DataLoader.LoadProducts();
            var list1 = from p in products
                        group p.UnitsInStock by p.Category into g
                        select new { Category = g.Key, Sum = g.ToList().Sum() };
            string line = "{0,-30} {1,5}";
            Console.WriteLine(line, "Category", "Sum");
            Console.WriteLine("=====================================================");

            foreach (var x in list1)
            {
                Console.WriteLine(line, x.Category, x.Sum);
            }
            Console.WriteLine("=====================================================");

        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            List<Product> products = DataLoader.LoadProducts();
            var list1 = from p in products
                        orderby p.UnitPrice
                        group p.ProductName by p.Category into g
                        select new { Category = g.Key, Name = g.ToList().First() };

            
            string line = "{0,-30} {1,5}";
            Console.WriteLine(line, "Category", "Cheapest Product");
            Console.WriteLine("=====================================================");

            foreach (var x in list1)
            {
                Console.WriteLine(line, x.Category, x.Name);
            }
            Console.WriteLine("=====================================================");

        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            List<Product> products = DataLoader.LoadProducts();
            var list1 = from p in products
                        group p.UnitPrice by p.Category into g
                        select new { Category = g.Key, AvgPrice = decimal.Round(g.ToList().Average(),2) };

            var list2 = (from l in list1
                         orderby l.AvgPrice descending
                         select l).Take(3);


            string line = "{0,-30} {1,5}";
            Console.WriteLine(line, "Category", "Avg. Price");
            Console.WriteLine("=====================================================");

            foreach (var x in list2)
            {
                Console.WriteLine(line, x.Category, x.AvgPrice);
            }
            Console.WriteLine("=====================================================");

        }
    }
}
