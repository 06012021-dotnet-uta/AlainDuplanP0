using System;
using System.Collections;
using P0Context;
using System.Linq;

namespace P0{
    public class Store{

        public string name {get; set;}
        public string location{get; set;}

        private readonly ShopperContext _context;
        public  Store() { }
        public  Store(ShopperContext context)
        {
            this._context = context;
        }
        //var stores = _context.Stores.ToList();

        //private List<Order> orders = new List<Order>();

        //private Dictionary<string, Inventory> inventory = new Dictionary<string, Inventory>();

        /*public Store(){
             name = "Unnamed store, you should name it";
             location = "no location data given";
         } */

        public Store(string name){
             this.name = name;
             location = "no location data given";
         }

         public Store(string name, string location){
             this.name = name;
             this.location = location;
         }

         /*public Dictionary<string, Inventory> getInventory(){
             return inventory;
         }*/

        //  public void addItem(Item item, int quantity = 1){
        //      if(item.exists()){
        //          local = inventory(item.name);
        //          local[1]+= quantity;
        //      }
        //      else {
        //          inventory.add(item.name, [item, quantity]);
        //      }
        //  }

        /*public Item getItem(string name){
            if(inventory.containsKey(name))
                return inventory[name];
            else
                return null;
        } */
         
         /*public bool checkout(Inventory item){
            if(!inventory.containsKey(item.name))
                return false;
            Inventory curr = inventory[item.name];
            
            if(curr.quantity == 0){
                return false;
            if(curr.quantity < item.quantity)
                item.quantity = curr.quantity;
  
            curr.quantity -= item.quantity;
            return true;
           
         }*/

        
       /* public List<Order> getOrder(){
            return orders;
        }
        public List<Order> addOrder(Order order){
            orders.add(order);
        }*/
    }

}