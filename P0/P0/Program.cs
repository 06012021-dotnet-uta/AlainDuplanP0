using System;
using P0Context;
using System.Linq;
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
                #region User Stuff
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
                #endregion
                #region Store Stuff
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
                #endregion
                #region Order stuff
                if (next == 3) // make a new order/past
                {
                    OrderInfo orderInfo = new OrderInfo();
                    Model.Order order = new Model.Order();
                    StoreInfo storeInfo = new StoreInfo();
                    
                    order.customer = cust;
                    

                    int oNext = orderInfo.whatNext();
                    if (oNext == 1)//check past order
                    {
                        string finalCheck = orderInfo.getOrderHistory(order);
                        if(finalCheck == "Ooops, looks you made no orders yet")
                        {
                            Console.WriteLine(finalCheck);
                            nextCheck = false;
                            continue;
                        }
                        Console.WriteLine(finalCheck);
                        Console.WriteLine();
                        order.id = orderInfo.storeSelect().id;
                        
                        Console.WriteLine(orderInfo.getInventory(order));
                        Console.WriteLine("\nReturning you to the main Screen now.\n");
                    }
                    if (oNext == 2)//make new order
                    {
                        NewOrder newOrder = new NewOrder();
                        order.store = newOrder.storeSelect().id;
                        //Console.WriteLine("\nReturning you to the main Screen now.\n");
                        bool getCheck = newOrder.takeItem(order);
                        
                        if (getCheck)
                        {
                            string confirm = "";
                            
                            while (confirm != "yes")
                            {
                                order = newOrder.getItem(order);
                                Console.WriteLine($"Your cart total is ${order.getTotal()}.Ready to check out? Enter yes to check out or something else to kep shopping");
                                Console.WriteLine("Remember this is final so be careful");
                                confirm = Console.ReadLine().ToLower();                               
                            }
                            Console.WriteLine($"Wow your going to spend ${order.getTotal()}. This is the last chance to back out");
                            Console.WriteLine("ENTER 'YES' TO FINALIZE");
                            string last = Console.ReadLine().ToLower();
                            if(last == "yes")
                            {
                                Console.WriteLine("Bold, well we are finallizing your order now. Please wait, my computer has low memory.");
                                int id = newOrder.finalized(order);
                                Console.WriteLine($"We finalized your order at Store #{order.store}. You spent a total of ${order.getTotal()}. Your Order ID is {id}");
                            }
                            else
                            {
                                Console.WriteLine("Smart choice, I dont have to go to the trouble of restocking");
                            }
                            Console.WriteLine("\nReturning you to the main Screen now.\n");
                        }
                        else
                        {
                            Console.WriteLine("\nWe have to start you over.\nReturning you to the main Screen now.\n");
                        }

                    }
                    if (oNext == 3) // exit
                    {
                        nextCheck = false;
                    }

                }
                #endregion
                #region Add Stuff
                if (next == 4) // add stuff
                {
                    Adding adding = new Adding();
                    int aNext = adding.whatNext();
                    if(aNext == 1)//add store
                    {
                        Console.WriteLine("\nLets Open a Store");
                        adding.inputArr(adding.nameInput());
                        Console.WriteLine("\nReturning you to the main Screen now.\n");
                    }
                    if (aNext == 2)//restock                        
                    {

                        AddingItem newItem = new AddingItem();
                        newItem.finalize();
                        Console.WriteLine("\nReturning you to the main Screen now.\n");
                    }
                    if (aNext == 3)//exit
                    {
                        nextCheck = false;
                    }
                    Console.WriteLine("\nReturning you to the main Screen now.\n");

                }
                #endregion
                if (next == 5) // exit
                {
                    nextCheck = true;
                }
            }//nextCheck

        }//main
    }//class
}//namespace
