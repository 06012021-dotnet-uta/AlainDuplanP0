using System;

namespace RockPaperScissors1
{
    partial class Program
    {
        public enum RPSChoice{
            Rock, // equals 0
            Paper, // equals 1
            Scissors // equals 2
        }
        static void Main(string[] args)    
        {

                     
            int ties = 0;
            string input = "x";
            RpsGame game = new RpsGame();
            PlayerDerivedClass player1 = new PlayerDerivedClass();
            PlayerDerivedClass computer = new PlayerDerivedClass("Master", "Mind");
            

            Console.WriteLine(game.WelcomeMessage());
            player1.Fname = Console.ReadLine();
            Console.WriteLine("What is your last name?");
            player1.Lname = Console.ReadLine();

            Console.WriteLine($"Get ready for a heated battle {player1.getFullName()}!");
           

            while(input == "x"){
                
                        
            // get a random number
            player1.choice = game.playerChoice(player1.getFullName());

            Random rand = new Random();
            // 1, 2, or 3
            computer.choice = rand.Next(1, 4);

            //print the choices
            Console.WriteLine($"\n{player1.getFullName()}'s choice is {player1.choice}.");
            Console.WriteLine($"The {computer.getFullName()}'s choice is {computer.choice}.");

            //check who won
            PlayerDerivedClass winner = game.matchWinner(player1, computer);

            if(winner == player1)
                player1.wins = player1.wins + 1;
            else if(winner == computer)
                computer.wins = computer.wins + 1;
            else
                ties++;
            
            //match set
            PlayerDerivedClass gameWinner = game.gameWinner(player1, computer, ties);

            if(gameWinner == player1){
                input = Console.ReadLine();
                ties = 0;
            }
            else if(gameWinner == computer){
                input = Console.ReadLine();
                ties = 0;
            }
            else
                continue;


    
        }
    }
}
}

