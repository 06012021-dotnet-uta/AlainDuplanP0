using System;
using P0Context;
using System.Linq;
using P0Logic;
using Model;

namespace P0
{
    class Program
    {
        static void Main(string[] args)
        {
            ShopperContext context = new ShopperContext();
            
               
            User cust = null; // customer user to be used 
            int CId; // customer id

            #region Prompts for creating a new customer and logging in
            Login x = new Login();

            Login login = new Login();
            string input = login.welcomePrompt();
            if (input.ToLower() == "yes")
            {
                string[] nameArr = login.nameInput();
                cust = new User(nameArr[0], nameArr[1]);
                Customer custEnt = new Customer();
                custEnt.CustomerFname = nameArr[0]; custEnt.CustomerLname = nameArr[1];
                context.Customers.Add(custEnt);
                context.SaveChanges();
                int CustID = context.Customers.OrderByDescending(x => x.CustomerId).Select(x => x.CustomerId).FirstOrDefault();
                cust.id = CustID;
                Console.WriteLine($"Your Customer Id is {CustID} and your name is {cust.fname} {cust.lname}");
            }//end if
            while (cust == null){
                bool check = false;
                while (!check){
                    string[] nameArr = login.nameInput();
                    var choices = context.Customers.Where(x => x.CustomerFname.Contains(nameArr[0]) && x.CustomerLname.Contains(nameArr[1])).ToList();
                    if (!choices.Any()){
                        Console.WriteLine("No customer found. Try again");
                        check = false;
                    }//end if
                    foreach (var c in choices){
                        Console.WriteLine($"Customer found: {c.CustomerFname} {c.CustomerLname}, ID: {c.CustomerId}");
                        check = true;
                    }//end foreach
                }//end inner whileloop
                CId = login.checkId();
                var temp = context.Customers.Where(x => x.CustomerId == CId);

                if (!temp.Any())
                    Console.WriteLine("Customer ID was not found");
                else{
                    cust = new User(context, CId);
                    Console.WriteLine($"Your Customer Id is {cust.id} and your name is {cust.fname} {cust.lname}. Welcome!");
                }//end else
            }//end outer whilelooop
            #endregion

            int next = login.whatNext();// activates next prompt
            if(next == 1) // check user history
            {

            }
            if(next == 2) //check store history
            {

            }
            if(next == 3) // make a new order
            {

            }

        }//main
    }//class
}//namespace
