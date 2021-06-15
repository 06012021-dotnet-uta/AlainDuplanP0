using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P0Context;
using Model;

namespace Businesss
{
    /// <summary>
    /// Used to add to database
    /// </summary>
    public class Adding : AHelpers, GHelpers
    {
        ShopperContext context = new ShopperContext();
        /// <summary>
        /// Displays menu and waits for a valid user input
        /// </summary>
        /// <returns>Valid input</returns>
        public int whatNext()
        {
            Console.WriteLine("What would you want to do next?");
            Console.WriteLine("Enter 1: Add store");
            Console.WriteLine("Enter 2: Restock");
            Console.WriteLine("Enter 3: Return to menu");
            string input = Console.ReadLine();
            int output = isThisAnInt(input);
            if (output > 3 || output < 1)
            {
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
        public int isThisAnInt(string input)
        {
            int output;
            bool sucessfulConversion = Int32.TryParse(input, out output);
            while (!sucessfulConversion)
            {
                Console.WriteLine("input is in the incorrect format, enter a new one");
                Console.WriteLine("Enter 1: Add store");
                Console.WriteLine("Enter 2: Restock");
                Console.WriteLine("Enter 3: Return to menu");
                input = Console.ReadLine();
                sucessfulConversion = Int32.TryParse(input, out output);
            }
            return output;
        }
        
        /// <summary>
        /// Asks for name and location, checks if input is too long
        /// </summary>
        /// <returns>name and location as a array of strings</returns>
        public string[] nameInput()
        {
            Console.WriteLine("Enter your store name");
            string Fname = Console.ReadLine().Trim();
            Console.WriteLine("Enter your store location");
            string Lname = Console.ReadLine().Trim();
            string[] arr = { Fname, Lname };
            if (Fname.Length > 50 || Lname.Length > 100)
            {
                Console.WriteLine("\nExcuse me but your name is a bit too long, try again.");
                arr = nameInput();

            }
            return arr;
        }
        /// <summary>
        /// Builds a store object and saves it to the database
        /// </summary>
        /// <param name="nameArr">name and location</param>       
        public void inputArr(string[] nameArr)
        {
            Model.Store cust = new Model.Store(nameArr[0], nameArr[1]);
            P0Context.Store custEnt = new P0Context.Store();
            custEnt.StoreName = nameArr[0]; custEnt.StoreLocation = nameArr[1];
            context.Stores.Add(custEnt);
            context.SaveChanges();
            int CustID = context.Stores.OrderByDescending(x => x.StoreId).Select(x => x.StoreId).FirstOrDefault();
            cust.id = CustID;
            Console.WriteLine($"Your Store Id is {CustID} and your name is {cust.name}  at {cust.location}");
            
        }

    }//class
}//namespace
