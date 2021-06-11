using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace P0Logic
{
    public class Login
    {
        public string welcomePrompt(){   Console.WriteLine("Welcome, are you a new customer? Type yes or no.");
            string input = Console.ReadLine();
            while (input.ToLower() != "yes" && input.ToLower() != "no")
            {
                Console.WriteLine("Input incorrect, enter yes or no");
                input = Console.ReadLine().Trim();
            }
            return input;
        }
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
        public string[] nameInput() {
            Console.WriteLine("Enter your first name");
            string Fname = Console.ReadLine().Trim();
            Console.WriteLine("Enter your last name");
            string Lname = Console.ReadLine().Trim();
            string[] arr = {Fname, Lname};
            return arr;
        }

        public int whatNext()
        {
            Console.WriteLine("What would you want to do next?");
            Console.WriteLine("Enter 1: Check User Order History");
            Console.WriteLine("Enter 2: Check Store Order History");
            Console.WriteLine("Enter 3: Make a new Order");
            string input = Console.ReadLine();
            int output = isThisAnInt(input);
            if(output > 3 || output < 1){
                Console.WriteLine("Input was not an option");
                output = whatNext();
            }
            return output;
        }

        public int isThisAnInt(string input){
            int output;
            bool sucessfulConversion = Int32.TryParse(input, out output);
            while (!sucessfulConversion){
                Console.WriteLine("input is in the incorrect format, enter a new one");
                Console.WriteLine("Enter 1: Check User Order History");
                Console.WriteLine("Enter 2: Check Store Order History");
                Console.WriteLine("Enter 3: Make a new Order");
                input = Console.ReadLine();
                sucessfulConversion = Int32.TryParse(input, out output);
            }
            return output;
        }
        
    }
}
