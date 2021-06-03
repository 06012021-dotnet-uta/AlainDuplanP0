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

            Console.WriteLine($"Get ready for a heated battle {player1.getFullName()}!\n Press ENTER to continue.");
           

            while(input == "x"){
                
                        
            // get a random number
            player1.choice = game.playerChoice(Console.ReadLine(), player1.getFullName());

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


            // if(player1.wins < 2 && computer.wins < 2){
            //     Console.WriteLine($"{player1.getFullName()} won {player1.getFullName()} times and {computer.getFullName()} won {computer.wins} times with {ties} ties.");
            //     Console.WriteLine("No winner yet, starting new match!");
            //     continue;
            // }
            // if(player1.wins == 2){
            //     totalPlayerWins++;
            //     Console.WriteLine($"{player1.getFullName()} won {player1.getFullName()} times and {computer.getFullName()}d won {computer.wins} times with {ties} ties.");
            //     Console.WriteLine($"{player1.getFullName()} wins!\n{player1.getFullName()} has {totalPlayerWins} wins under his belt with {totalCompWins} losses.  \nPress X to start a new game or something else to quit.");
            //     input = Console.ReadLine();
            //     player1.wins = 0;
            //     computer.wins = 0;
            //     ties = 0;
                
            // }
            // if(computer.wins == 2){
            //     totalCompWins++;
            //     Console.WriteLine($"{player1.getFullName()} won {player1.getFullName()} times and Computer won {computer.wins} times with {ties} ties.");
            //     Console.WriteLine($"Computer wins! \n{player1.getFullName()} has {player1.getFullName()} wins under his belt with {totalCompWins} losses.  \nxPress X to start a new game or something else to quit..");
            //     input = Console.ReadLine();
            //     player1.wins = 0;
            //     computer.wins = 0;
            //     ties = 0;
                   
            // }
        }
    }
}
}

