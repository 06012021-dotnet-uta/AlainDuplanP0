using System;

namespace P0{
    public class Store{

        public string name {get; set;}
        public string location{get; set;}

        //private List<Order> orders = new List<Order>();

        //private Dictionary<string, [Item, int]]> inventory = new Dictionary<string, [Item, int]>();
         public Store(){
             name = "Unnamed store, you should name it";
             location = "no location data given";
         }

         public Store(string name){
             this.name = name;
             location = "no location data given";
         }

         public Store(string name, string location){
             this.name = name;
             this.location = location;
         }

        //  public Dictionary<string, int> getInventory{
        //      return inventory;
        //  }
        //  public void addItem(Item item, int quantity = 1){
        //      if(item.exists()){
        //          local = inventory(item.name);
        //          local[1]+= quantity;
        //      }
        //      else {
        //          inventory.add(item.name, [item, quantity]);
        //      }
        //  }

        //  public [] getItem{string name}{
        //      return inventory(name);
        //  }
         
        //  public bool checkout(Item item, quantity = 1){
        //     itemList = getItem(item.name);
        //     if(itemList[1] == 0)
        //         return false;
        //     else{
        //         item[1] -= quantity;
        //         return true
        //     }
        //  }

        
        // public List<Order> getOrder(){
        //     return orders;
        // }
        // public List<Order> addOrder(Order order){
        //     orders.add(order);
        // }
    }

}