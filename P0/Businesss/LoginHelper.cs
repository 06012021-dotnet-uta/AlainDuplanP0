using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace Businesss
{
    /// <summary>
    /// Helps LoginContext performs functions
    /// </summary>
    public class LoginHelper : GHelpers, LHHelpers
    {
        /// <summary>
        /// Dsplays welcome prompt for ne and returning customers
        /// </summary>
        /// <returns>String yes/no </returns>
        public string welcomePrompt(){   Console.WriteLine("Welcome, are you a new customer? Type yes or no.");
            string input = Console.ReadLine();
            while (input.ToLower() != "yes" && input.ToLower() != "no")
            {
                Console.WriteLine("Input incorrect, enter yes or no");
                input = Console.ReadLine().Trim();
            }
            return input;
        }
        /// <summary>
        /// Asks user for an ID to search for user
        /// </summary>
        /// <returns>A valid ID</returns>
        public int checkId() {
            Console.WriteLine("Enter the CustomerID of the User you would like to use");
            string input = Console.ReadLine();
            int CId;
            bool sucessfulConversion = Int32.TryParse(input, out CId);
            while (!sucessfulConversion){
                Console.WriteLine("Id is in the incorrect format, enter a new one");
                input = Console.ReadLine();
                sucessfulConversion = Int32.TryParse(input, out CId);
            }
            return CId;
        }
        /// <summary>
        /// Asks for first and last name, checks if input is too long
        /// </summary>
        /// <returns>first and last name as a array of strings</returns>
        public string[] nameInput() {
            Console.WriteLine("Enter your first name");
            string Fname = Console.ReadLine().Trim();
            Console.WriteLine("Enter your last name");
            string Lname = Console.ReadLine().Trim();
            string[] arr = { Fname, Lname };
            if (Fname.Length > 30 || Lname.Length > 30)
            {
                Console.WriteLine("\nExcuse me but your name is a bit too long, try again.");
                arr = nameInput();

            }
            return arr;
        }
        /// <summary>
        /// Displays menu and waits for a valid user input
        /// </summary>
        /// <returns>Valid input</returns>
        public int whatNext()
        {
            Console.WriteLine("What would you want to do next?");
            Console.WriteLine("Enter 1: Check User");
            Console.WriteLine("Enter 2: Check Store");
            Console.WriteLine("Enter 3: Check Order");
            Console.WriteLine("Enter 4: Add Data");
            Console.WriteLine("Enter 5: Exit");
            string input = Console.ReadLine();
            int output = isThisAnInt(input);
            if(output > 5 || output < 1){
                Console.WriteLine("Input was not an option");
                output = whatNext();
            }
            return output;
        }
        /// <summary>
        /// Checks if input was an int and loops until valid input is given
        /// </summary>
        /// <param name="input">Input string from ReadLine</param>
        /// <returns>An int input</returns>
        public int isThisAnInt(string input){
            int output;
            bool sucessfulConversion = Int32.TryParse(input, out output);
            while (!sucessfulConversion){
                Console.WriteLine("input is in the incorrect format, enter a new one");
                Console.WriteLine("Enter 1: Check User");
                Console.WriteLine("Enter 2: Check Store");
                Console.WriteLine("Enter 3: Check Order");
                Console.WriteLine("Enter 4: Add Data");
                Console.WriteLine("Enter 5: Exit");
                input = Console.ReadLine();
                sucessfulConversion = Int32.TryParse(input, out output);
            }
            return output;
        }
        
    }
}
