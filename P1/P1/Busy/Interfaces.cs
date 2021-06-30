using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busy
{
    public interface INewOrder
    {
        public bool checkStore(int id);
        public ModelsDefault.Order startOrder(ModelsDefault.Order order);
        public bool checkItem(int id, int item);
        public bool checkQuantity(int id, int item, int quant);
        public bool checkDuplicates(int id, int item);
        public ModelsDefault.Order buildOrder();
        public void updateOrder(int id, int item, int quant, int store);
    }

    public interface ISignUP 
    {
        public Task<bool> registerUser(string fname, string lname, int top);
        public int getID();
        public bool checkID(int id);
        public ModelsDefault.User getUser(ModelsDefault.User user);
    }

    public interface IStoreSearch 
    {
        public ArrayList listsStores(ModelsDefault.User user);
        public ArrayList getOrders(ModelsDefault.Store cust);
        public ModelsDefault.Store getStore(string name, string location);
        public ModelsDefault.Store getStore2(int id);
        public ArrayList getInventory(ModelsDefault.Store store);
        public void addItem(int add, ModelsDefault.Inventory inv);
        public ArrayList getInventorybyID(int id);

    }
    public interface IUserOrders
    {
        public ArrayList getOrders(ModelsDefault.User cust);
        public ArrayList getOrderItems(ModelsDefault.Order order);

    }
    public interface IUserSearch
    {
        public ArrayList listUsers(ModelsDefault.User user);
    }
}
