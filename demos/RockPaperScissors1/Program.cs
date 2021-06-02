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
            int playerWins = 0;
            int compWins = 0;
            int ties = 0;
            string input = "x";
            int totalPlayerWins = 0;
            int totalCompWins = 0;

            Console.WriteLine("Welcome to Janken! \nWhat is your name?");
            string playerName = Console.ReadLine();

            while(input == "x"){
            Console.WriteLine("\nPlease make a choice.");

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
                    Console.WriteLine($"\n{playerName}, you inputted {playerChoiceInt}. That is not a valid choice.");
                else if (!sucessfulConversion)
                    Console.WriteLine($"\n{playerName}, you inputted {playerChoice}. That is not a valid choice.");

            } //  while(!sucessfulConversion || (playerChoiceInt < 1  && playerChoiceInt > 3))
            while(!sucessfulConversion || !(playerChoiceInt > 0  && playerChoiceInt < 4));
;

             if (sucessfulConversion == true)
                Console.WriteLine($"\nthe conversion returned {sucessfulConversion} and {playerName} chose {playerChoiceInt}.");
            else
                Console.WriteLine($"\nthe conversion returned {sucessfulConversion} and {playerName} chose {playerChoiceInt}.");
            
            // get a random number
            Random rand = new Random();
            // 1, 2, or 3
            int computerChoice = rand.Next(1, 4);

            //print the choices
            Console.WriteLine($"\n{playerName}'s choice is {playerChoiceInt}.");
            Console.WriteLine($"The compututer's choice is {computerChoice}.");

            //check who won
            if (playerChoiceInt == 1 && computerChoice == 2
            || playerChoiceInt == 2 && computerChoice == 3
            || playerChoiceInt == 3 && computerChoice == 1){
                Console.WriteLine("\nComputer wins the match.");
                compWins++;
            }
            else if (playerChoiceInt == computerChoice){
                Console.WriteLine("\nTie.");
                ties++;
            }
            else{
                Console.WriteLine($"\n{playerName} wins the match.");
                playerWins++;
            }
            if(playerWins < 2 && compWins < 2){
                Console.WriteLine($"{playerName} won {playerWins} times and Computer won {compWins} times with {ties} ties.");
                Console.WriteLine("No winner yet, starting new match!");
                continue;
            }
            if(playerWins == 2){
                totalPlayerWins++;
                Console.WriteLine($"{playerName} won {playerWins} times and Computer won {compWins} times with {ties} ties.");
                Console.WriteLine($"{playerName} wins!\n{playerName} has {totalPlayerWins} wins under his belt with {totalCompWins} losses.  \nPress X to start a new game or something else to quit.");
                input = Console.ReadLine();
                playerWins = 0;
                compWins = 0;
                ties = 0;
                
            }
            if(compWins == 2){
                totalCompWins++;
                Console.WriteLine($"{playerName} won {playerWins} times and Computer won {compWins} times with {ties} ties.");
                Console.WriteLine($"Computer wins! \n{playerName} has {totalPlayerWins} wins under his belt with {totalCompWins} losses.  \nxPress X to start a new game or something else to quit..");
                input = Console.ReadLine();
                playerWins = 0;
                compWins = 0;
                ties = 0;
                   
            }
        }
    }
}
}

