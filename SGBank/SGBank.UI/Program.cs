using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Menu.Start();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("A severe error occurred....");
                Console.WriteLine("Account database missing, contact IT ");
                Console.WriteLine("Please any key to exit the application..");
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine("A severe error occurred....");
                Console.WriteLine("Contact IT and provide the following info: ");
                Console.WriteLine("Error Message : {0}", ex.Message);
                Console.WriteLine("Error occurred at : {0}", ex.StackTrace);

                Console.WriteLine("Please any key to exit the application..");
                Console.ReadLine();
            }
        }
    }
}
