using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyHearts
{
    class Program
    {
        static void Main(string[] args)
        {
            int User_Age = 0;

            while(true)
            {
                Console.Write("What is your age? ");
                string Input_Age_String = Console.ReadLine();
                if (int.TryParse(Input_Age_String,out User_Age))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("That was not a valid age,please try again..");
                    
                }
            }

            int Max_Heart_Rate = 220 - User_Age;
            int Min_Heart_Rate = ((int)Math.Floor(Max_Heart_Rate * 0.5));
            int Avg_Heart_Rate = ((int)Math.Ceiling(Max_Heart_Rate * 0.85));
            
            if (User_Age >= 220)
            {
                Console.WriteLine("You have lived too far. I don't have any stats for you!");
               
            }
            else
            {
                Console.WriteLine("Your maximum heart rate should be {0} beats per minute", Max_Heart_Rate);
                Console.WriteLine("Your target HR Zone is {0} - {1} beats per minute", Min_Heart_Rate, Avg_Heart_Rate);
            }

            Console.ReadLine();


        }
    }
}
