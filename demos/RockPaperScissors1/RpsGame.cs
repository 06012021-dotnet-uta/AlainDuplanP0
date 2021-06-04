using System;
namespace RockPaperScissors1
{
    public class RpsGame
    {
         /// <summary>
         /// Returns string containing the welcome message.
         /// </summary>
         /// <returns>Welcome message</returns>   
        public string WelcomeMessage(){
            string welcome = "Welcome to Janken! \nWhat is your name?";
            return welcome;
        }
        /// <summary>
        /// Takes a string input and returns a string if parameters are met, otherwise will return null.
        /// Input cannot be empty nor greater than twenty characters.
        /// </summary>
        /// <param name="playerInput">name that is inputted by the player</param>
        /// <returns>Trimmed string if valid, else will return null</returns>
        public string getPlayerName(string playerInput){
            playerInput = playerInput.Trim();
            if (playerInput.Length > 20 || playerInput.Length < 1)
            {
                return null;
            }
            return playerInput;
        }
        /// <summary>
        /// Takes player name as an input and returns player choice if valid.
        /// Displays prompts for player to input a choice.
        /// If choice is invalid, prompt will continue to appear until valid prompt is entered
        /// </summary>
        /// <param name="name">Name of the Player</param>
        /// <returns>Player choice in the form as a int</returns>
        public int playerChoice(string name){
            bool sucessfulConversion = false;
            int playerChoiceInt;
            string playerName = name;
            do
            {
                Console.WriteLine("\nPlease make a choice.");
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
            return playerChoiceInt;
    }

        public PlayerDerivedClass matchWinner(PlayerDerivedClass player, PlayerDerivedClass computer){
            if (player.choice == 1 && computer.choice == 2
            || player.choice == 2 && computer.choice == 3
            || player.choice == 3 && computer.choice == 1){
                Console.WriteLine($"\n{computer.getFullName()} wins the match.");
                return computer;
            }
            else if (player.choice == computer.choice){
                Console.WriteLine("\nTie.");
                return null;
            }
            else{
                Console.WriteLine($"\n{player.getFullName()} wins the match.");
                return player;
            }
            
        }

        public PlayerDerivedClass gameWinner(PlayerDerivedClass player, PlayerDerivedClass computer, int ties){
           if(player.wins < 2 && computer.wins < 2){
                Console.WriteLine($"{player.getFullName()} won {player.wins} times and {computer.getFullName()} won {computer.wins} times with {ties} ties.");
                Console.WriteLine("No winner yet, starting new match!\n Press Enter to continue.");
                return null;
            }
           else if(player.wins == 2){
                player.gameWins++;
                Console.WriteLine($"{player.getFullName()} won {player.wins} times and {computer.getFullName()}x won {computer.wins} times with {ties} ties.");
                Console.WriteLine($"{player.getFullName()} wins!\n{player.getFullName()} has {player.gameWins} wins under his belt with {computer.gameWins} losses.  \nPress X then enter to start a new game or something else to quit.");
                player.wins = 0;
                computer.wins = 0;
                return player;
                
            }
            else if(computer.wins == 2){
                computer.gameWins++;
                Console.WriteLine($"{player.getFullName()} won {player.wins} times and Computer won {computer.wins} times with {ties} ties.");
                Console.WriteLine($"Computer wins! \n{player.getFullName()} has {player.gameWins} wins under his belt with {computer.gameWins} losses.  \nPress X then enter to start a new game or something else to quit..");
                player.wins = 0;
                computer.wins = 0;
                return computer;
            }
            else
                return null;
        }
}
}