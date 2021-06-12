using System;
using P0Context;
using System.Linq;
using P0Logic;
using Model;
using Businesss;

namespace P0
{
    class Program
    {
        static void Main(string[] args)
        {
            
            User cust = null; // customer user to be used 
            int CId; // customer id

            
            LoginContext loginContext = new LoginContext(); // only calls context methods

            LoginHelper login = new LoginHelper(); // helps login context
            #region Prompts for creating a new customer and logging in
            string input = login.welcomePrompt();
            if (input.ToLower() == "yes")
            {
                cust = loginContext.inputYes(login.nameInput());
            }//end if
            while (cust == null){
                bool check = false;
                while (!check){
                    check = loginContext.checkInput(login.nameInput());
                }//end inner whileloop
                CId = login.checkId();
                cust = loginContext.checkId(CId);
            }//end outer whilelooop
            #endregion

            bool nextCheck = false;
            while (!nextCheck)
            {
                int next = login.whatNext();// activates next prompt
                if (next == 1) // check user history
                {
                    UserInfo userInfo = new UserInfo();
                    int uNext = userInfo.whatNext();
                    if (uNext == 1) // check user orders
                    {
                        Console.WriteLine(userInfo.displayInfo(cust));
                        Console.WriteLine("\nReturning you to the main Screen now.");

                    }
                    if (uNext == 2) //check order history
                    {
                        Console.WriteLine(userInfo.getOrderHistory(cust));
                    }
                    if (uNext == 3) // exit
                    {
                        nextCheck = false;
                    }

                }
                if (next == 2) //check store history
                {

                }
                if (next == 3) // make a new order
                {

                }
                if (next == 4) // exit
                {
                    nextCheck = true;
                }
            }//nextCheck

        }//main
    }//class
}//namespace
