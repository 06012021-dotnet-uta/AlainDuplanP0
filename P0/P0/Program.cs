using System;
using P0Context;
using System.Linq;

namespace P0
{
    class Program
    {
        static void Main(string[] args)
        {
            ShopperContext context = new ShopperContext();
            /*var choices = context.Customers.ToList();
            var stores = context.Stores.Where(x => x.StoreName == "walmart").ToList();

            foreach(var c in stores)
            {
                Console.WriteLine($"The customer is {c.StoreId}, {c.StoreName}");
            }
            */
            //var choices = context.Customers.ToList();

            #region Prompts for creating a new customer and logging in
            User cust = null;
            int CId;
            bool sucessfulConversion;
            Console.WriteLine("Welcome, are you a new customer? Type yes or no.");
            string input = Console.ReadLine();
            while(input.ToLower() != "yes" && input.ToLower() != "no"){
                Console.WriteLine("Input incorrect, enter yes or no");
                input = Console.ReadLine().Trim();
            }
            if(input.ToLower() == "yes"){
                Console.WriteLine("Enter your first name");
                string Fname = Console.ReadLine().Trim();
                Console.WriteLine("Enter your last name");
                string Lname = Console.ReadLine().Trim();
                cust = new User(Fname, Lname);
                Customer custEnt = new Customer();
                custEnt.CustomerFname = Fname; custEnt.CustomerLname = Lname;
                context.Customers.Add(custEnt);
                context.SaveChanges();
                int CustID = context.Customers.OrderByDescending(x => x.CustomerId).Select(x => x.CustomerId).FirstOrDefault();
                cust.id = CustID;
                Console.WriteLine($"Your Customer Id is {CustID} and your name is {cust.fname} {cust.lname}");
            }
            while(cust == null){
                Console.WriteLine("Enter your CustomerID");
                input = Console.ReadLine();
                sucessfulConversion = Int32.TryParse(input, out CId);
                while(!sucessfulConversion){
                        Console.WriteLine("Id is in the incorrect format, enter a new one");
                        input = Console.ReadLine();
                        sucessfulConversion = Int32.TryParse(input, out CId);
                    }
                var temp = context.Customers.Where(x => x.CustomerId == CId);

                if(!temp.Any())
                    Console.WriteLine("Customer ID was not found");
                else {
                        cust = new User(context, CId);
                        Console.WriteLine($"Your Customer Id is {cust.id} and your name is {cust.fname} {cust.lname}. Welcome!");
                }
            }
            #endregion
        }//main
    }//class
}//namespace
