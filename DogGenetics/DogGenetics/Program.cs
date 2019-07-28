using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogGenetics
{
    class Program
    {
        static void Main(string[] args)
        {
            String Dog_Name;
            int Sum = 0;
            int[] num = new int[5];
            Random Random_percent = new Random();

            while (true)
            {
                Console.Write("What is your dog's name? ");
                Dog_Name = Console.ReadLine();
                if (string.IsNullOrEmpty(Dog_Name))
                {
                    Console.WriteLine("Did you hit enter too early? Please try again..");
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine($"Well then, I have this highly reliable report on {Dog_Name}'s prestigious background right here.");
            Console.WriteLine();
            Console.WriteLine($"{Dog_Name} is");
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                if (i == 4)
                {
                    num[i] = 100 - Sum;
                }

                else
                {
                    num[i] = Random_percent.Next(100 - Sum);
                    Sum += num[i];
                }
                switch (i)
                {
                    case 0:
                        Console.WriteLine("{0}% St. Bernard", num[i]);
                        continue;
                    case 1:
                        Console.WriteLine("{0}% Chihuahua", num[i]);
                        continue;
                    case 2:
                        Console.WriteLine("{0}% Dramatic RedNosed Asian Pug", num[i]);
                        continue;
                    case 3:
                        Console.WriteLine("{0}% Common Cur", num[i]);
                        continue;
                    case 4:
                        Console.WriteLine("{0}% King Doberman", num[i]);
                        continue;
                }
                
            }
            Console.WriteLine();
            Console.WriteLine("Wow, that's QUITE the dog!");
            Console.ReadLine();
            
            }
    }
}
