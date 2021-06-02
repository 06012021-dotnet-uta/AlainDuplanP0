using System;

namespace RockPaperScissors1
{
    class Program
    {
        public enum RPSChoice{
            Rock, // equals 0
            Paper, // equals 1
            Scissors // equals 2
        }
        static void Main(string[] args)
        {
            //int playerWins = 0;
            //int compWins = 0;

            Console.WriteLine("Welcome to Janken! \nPlease make a choice");


            bool sucessfulConversion = false;
            int playerChoiceInt;
            do
            {
                Console.WriteLine("1. Rock \n2. Paper\n3. Scissors");
                string playerChoice = Console.ReadLine();

                //creat a int variable to catch converted choice
                
                sucessfulConversion = Int32.TryParse(playerChoice, out playerChoiceInt);

                //check if the user inputted a number that is out of bounds
                if (playerChoiceInt > 3 || playerChoiceInt <1)
                {
                    Console.WriteLine($"You inputted {playerChoiceInt}. That is not a valid choice.");
                }
                else if (!sucessfulConversion)
                {
                    Console.WriteLine($"You inputted {playerChoice}. That is not a valid choice.");
                }

            } while (!sucessfulConversion && (playerChoiceInt < 1 || playerChoiceInt > 3));

            /*
            if (sucessfulConversion == true)
            {
                Console.WriteLine($"the conversion returned {sucessfulConversion} and the player chose {playerChoiceInt}");
            }
            else
            {
                Console.WriteLine($"the conversion returned {sucessfulConversion} and the player chose {playerChoiceInt}");
            }
            */
        }
    }
}
