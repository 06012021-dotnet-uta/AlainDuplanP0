using System;
using System.Collections;
namespace P0{
    public class User{
        
        public string fname {get; set;}
        public string lname {get; set;}

        private int id;
        private List<Order> orders = new List<Order>();
        private List<Inventory> history = new List<Inventory>();
        private Item top;

        public Store store{get; set;}
        private Random rand = new Random();
        
        public User(string fname, string lname, Store store = null/*, List<int> allIds */){
            id = rand.Next(10, 9999);
            //while(allIds.contains(id))
               // id = rand.Next(10, 9999);
            this.fname = fname;
            this.lname = lname;
            this.store = store;
            top = null;
        }

        public int getId(){
            return id;
        }

        public List<Order> getOrder(){
            return orders;
        }
        public List<Order> addOrder(Order order){
            orders.add(order);
        }

        public List<Inventory> getHistory(){
            return history;
         }

         public void addItem(Item item, int quantity = 1){
             if(item.exists()){
                history[item] += quantity;
             }
             else {
                 history.add(new Inventory(item, quantity));
             }
             top = history.values.getMax;
         }

        
    }

}