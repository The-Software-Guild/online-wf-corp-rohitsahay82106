using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummativeSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Array1 = new int[] { 1, 90, -33, -55, 67, -16, 28, -55, 15 };
            int[] Array2 = new int[] { 999, -60, -77, 14, 160, 301 };
            int[] Array3 = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, -99 };

            Console.WriteLine($"#1 Array Sum: {AddArray(Array1)}");
            Console.WriteLine($"#2 Array Sum: {AddArray(Array2)}");
            Console.WriteLine($"#3 Array Sum: {AddArray(Array3)}");

            Console.ReadLine();
        }

        static int AddArray(int[] Array)
        { 
           int Arraysize = Array.GetLength(0);
           int Sum = 0;
           int i = 0;

           for (i=0; i<Arraysize; i++)
           {
              Sum += Array[i];                            
           }

           return Sum;

        }
    }
}
