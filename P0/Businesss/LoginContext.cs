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
    /// Handles logging in
    /// </summary>
    public class LoginContext : LHelpers
    {
        ShopperContext context = new ShopperContext();
        /// <summary>
        /// Builds a user object and saves it to the database
        /// </summary>
        /// <param name="nameArr">First name and last name</param>
        /// <returns>new user object</returns>
        public User inputYes(string[] nameArr)
        {
            User cust = new User(nameArr[0], nameArr[1]);
            Customer custEnt = new Customer();
            custEnt.CustomerFname = nameArr[0]; custEnt.CustomerLname = nameArr[1];
            context.Customers.Add(custEnt);
            context.SaveChanges();
            int CustID = context.Customers.OrderByDescending(x => x.CustomerId).Select(x => x.CustomerId).FirstOrDefault();
            cust.id = CustID;
            Console.WriteLine($"Your Customer Id is {CustID} and your name is {cust.fname} {cust.lname}");
            return cust;
        }
        /// <summary>
        /// searchs and prints customers based on name
        /// </summary>
        /// <param name="nameArr">First name and last name</param>
        /// <returns>if a customer was found</returns>
        public bool checkInput(string [] nameArr)
        {
            var choices = context.Customers.Where(x => x.CustomerFname.Contains(nameArr[0]) && x.CustomerLname.Contains(nameArr[1])).ToList();
            if (!choices.Any())
            {
                Console.WriteLine("No customer found. Try again");
                return false;
            }//end if
            foreach (var c in choices)
            {
                Console.WriteLine($"Customer found: {c.CustomerFname} {c.CustomerLname}, ID: {c.CustomerId}");
            }//end foreach
            return true;
        }
        /// <summary>
        /// Asks user for an ID to search for user
        /// </summary>
        /// <returns>A user</returns>
        public User checkId(int CId)
        {
            var temp = context.Customers.Where(x => x.CustomerId == CId);

            if (!temp.Any())
            {
                Console.WriteLine("Customer ID was not found");
                return null;
            }
            else
            {
                User cust = new User(context, CId);
                Console.WriteLine($"Your Customer Id is {cust.id} and your name is {cust.fname} {cust.lname}. Welcome!");
                return cust;
            }

        }
    }//class
}//namespace