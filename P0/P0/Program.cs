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
                        Console.WriteLine("\nReturning you to the main Screen now.\n");

                    }
                    if (uNext == 2) //check order history
                    {
                        Console.WriteLine(userInfo.getOrderHistory(cust));
                        Console.WriteLine("\nReturning you to the main Screen now.\n");

                    }
                    if (uNext == 3) // exit
                    {
                        nextCheck = false;
                    }

                }
                if (next == 2) //check store history
                {
                    StoreInfo storeInfo = new StoreInfo();
                    Console.WriteLine("We will just assume your an admin");
                    Model.Store store = storeInfo.storeSelect();
                    int sNext = storeInfo.whatNext();

                    if(sNext == 1)//check inventory
                    {
                        Console.WriteLine(storeInfo.getInventory(store));
                        Console.WriteLine("\nReturning you to the main Screen now.\n");
                    }
                    if (sNext == 2)//check past orders
                    {
                        Console.WriteLine(storeInfo.getOrderHistory(store));
                        Console.WriteLine("\nReturning you to the main Screen now.\n");

                    }
                    if (sNext == 3) // exit
                    {
                        nextCheck = false;
                    }

                }
                if (next == 3) // make a new order/past
                {
                    OrderInfo orderInfo = new OrderInfo();
                    Model.Order order = new Model.Order();
                    StoreInfo storeInfo = new StoreInfo();
                    
                    order.customer = cust;
                    

                    int oNext = orderInfo.whatNext();
                    if (oNext == 1)//check past order
                    {
                        Console.WriteLine(orderInfo.getOrderHistory(order));
                        Console.WriteLine();
                        order.id = orderInfo.storeSelect().id;
                        
                        Console.WriteLine(orderInfo.getInventory(order));
                        Console.WriteLine("\nReturning you to the main Screen now.\n");
                    }
                    if (oNext == 2)//make new order
                    {
                        order.store = storeInfo.storeSelect();
                        Console.WriteLine("\nReturning you to the main Screen now.\n");

                    }
                    if (oNext == 3) // exit
                    {
                        nextCheck = false;
                    }

                }
                if(next == 4) // add stuff
                {
                    Console.WriteLine("Sorry but I didnt get a chance to imnplement this yet.");
                    Console.WriteLine("\nReturning you to the main Screen now.\n");

                }
                if (next == 5) // exit
                {
                    nextCheck = true;
                }
            }//nextCheck

        }//main
    }//class
}//namespace
