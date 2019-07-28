using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            bool UserWantsToPlay = true;
            int No_of_Rounds = 0;
            string User_entry;
            string Ask_for_Rounds_Message = "How many rounds you want to play? Enter a number from 1 thru 10 : ";

            Console.WriteLine("You are going to play Rock Paper Scissors game. ");
            Console.WriteLine("You can choose to play a minimum of 1 round upto a max of 10 rounds");

            do
            {
                Console.WriteLine(Ask_for_Rounds_Message);
                User_entry = Console.ReadLine();
                UserWantsToPlay = false;
                if (int.TryParse(User_entry, out No_of_Rounds))
                {
                    if (No_of_Rounds > 10 || No_of_Rounds < 1)
                    {
                        InvalidRound();
                        break;
                    }
                    else
                    {
                        UserWantsToPlay = true;
                    }
                }
                else
                {
                    InvalidRound();
                    break;
                }

                string[] Score_Array = RPC_Game(No_of_Rounds);

                DisplayFinalScore(Score_Array);

                while (true)
                {
                    Console.WriteLine("Do you want to play again? Please enter Y or N : ");
                    User_entry = Console.ReadLine();
                    if (User_entry == "Y" || User_entry == "y" || User_entry == "N" || User_entry == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid response, please try again...");
                    }
                    
                }

                if (User_entry == "N" || User_entry == "n")
                {
                    UserWantsToPlay = false;
                    Console.WriteLine("Thanks for playing! Press any key to exit");
                    Console.ReadLine();
                }

            } while (UserWantsToPlay) ;

        }

        static int Get_UserInput(int Min, int Max, string Message)
        {
            int User_Input = 0;
            bool Valid_entry = false;

            while (!Valid_entry)
            { 
                Console.Write(Message);
                string User_Entry_String = Console.ReadLine();
            
                if (int.TryParse(User_Entry_String, out User_Input))
                {
                    Valid_entry = true;
                }
                else
                { 
                    Console.WriteLine("That was not a number, please try again..");
                }

                if (User_Input> Max || User_Input < Min)
                {
                    Valid_entry = false;
                }
                else
                {
                    Valid_entry = true;
                }
            }

            return User_Input;
        }

        static string[] RPC_Game(int No_of_Rounds)
        {
            int i = 0;
            string[] Score_Array = new string[No_of_Rounds];

            for (i = 0; i < No_of_Rounds; i++)
            {
            // 1=Rock; 2=Paper ; 3=Scissors
            //Rule: Paper>Rock; Scissors > Paper; Rock > Scissors

                int Min = 1;
                int Max = 3;
                int Result = 0;

                string Message = "Enter your Choice (1: Rock; 2: Paper; 3: Scissors): ";
                int User_Choice = Get_UserInput(Min, Max, Message);

                int Computer_Choice = 0;
                Random Random_Choice = new Random();
                Computer_Choice = Random_Choice.Next(Min, Max+1);
                Console.WriteLine(Computer_Choice);
                Result = User_Choice - Computer_Choice;
                switch(Result)
                    {
                    case 0:
                        Console.WriteLine("This a Tie");
                        Score_Array[i] = "Tie";
                        break;
                    case 1:
                    case -2:
                        Console.WriteLine("User Wins!! ");
                        Score_Array[i] = "User";
                        break;
                    case -1:
                    case 2:
                        Console.WriteLine("Hard Luck, The Computer Wins!! ");
                        Score_Array[i] = "Computer";
                        break;
                    }
            
            }

            return Score_Array;

        }

        static void DisplayFinalScore(string[] Score_Array)
        {

            string Round_Winner_Format = "{0,-10} | {1,-10}";
            Console.WriteLine();
            Console.WriteLine("___________________________");
            Console.WriteLine(Round_Winner_Format, "Round No.", "Winner");
            Console.WriteLine("___________________________");
            int Arraysize = Score_Array.GetLength(0);
            int i = 0;
            int Count_Of_UserWins = 0;
            int Count_Of_CompWins = 0;
            int Count_Of_Ties = 0;

            for (i = 0; i < Arraysize; i++)
            {
                int Round_No = i + 1;
                Console.WriteLine(Round_Winner_Format, Round_No, Score_Array[i]);
                switch (Score_Array[i])
                {
                    case "User":
                        Count_Of_UserWins++;
                        break;
                    case "Computer":
                        Count_Of_CompWins++;
                        break;
                    case "Tie":
                        Count_Of_Ties++;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Game Summary ");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Total number of rounds played:          {0}", Arraysize);
            Console.WriteLine("Total number of rounds won by user:     {0}", Count_Of_UserWins);
            Console.WriteLine("Total number of rounds won by Computer: {0}", Count_Of_CompWins);
            Console.WriteLine("Total number of rounds tied:            {0}", Count_Of_Ties);
            Console.WriteLine();
            if (Count_Of_UserWins>Count_Of_CompWins)
            {
                Console.WriteLine("The Winner of the Game is YOU!!!");
            }
            else if(Count_Of_UserWins < Count_Of_CompWins)
            {
                Console.WriteLine("The Winner of the Game is the computer. Better luck next time!");

            } 
            else
            {
                Console.WriteLine("It was a tied game!! May be you can try again!");
            }


                                                               
        }

        static void InvalidRound()
        {
            string Invalid_Round_Error_Message = "Looks like you do not want to play! GoodBye..  (Press any key to exit)";
            
            Console.WriteLine(Invalid_Round_Error_Message);
            Console.ReadLine();

        }
    }
}
