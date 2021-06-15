using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P0Context;
using Model;

namespace Businesss
{
    interface GHelpers // Generic Helpers

    {
        int whatNext();


        int isThisAnInt(string input);
    }
    interface ID // to check IDs
    {
        int checkId();
    }
    interface UHelpers //User Helpers

    {       
        string displayInfo(User cust);

        public string getOrderHistory(User cust);
    }
    interface SHelpers : ID //Store Helpers

    {
       string displayInfo(Model.Store cust);

        string getOrderHistory(Model.Store cust);

        string getInventory(Model.Store cust);

        Model.Store storeSelect();
    }

    interface OHelpers : ID//Order Helpers

    {      
        string getOrderHistory(Model.Order cust);

        string getInventory(Model.Order cust);

        Model.Order storeSelect();
    }

    interface NOHelpers : ID// New Order Helpers

    {
        Model.Order getItem(Model.Order cust);

        bool takeItem(Model.Order cust);

        int finalized(Model.Order cust);

        Model.Order storeSelect();
    }

    interface LHHelpers : ID
    {
        string[] nameInput();

        string welcomePrompt();
    }

    interface LHelpers
    {
        Model.User inputYes(string[] arr);

        bool checkInput(string[] arr);

        User checkId(int CId);

    }
    interface AHelpers
    {
        string[] nameInput();
        void inputArr(string[] nameArr);
    }

}
