using System;
using System.Collections;

namespace P0{
    public class Order{
        
    public Store store {get;}
    public User customer{get;}
    public DateTime time{get;}
    public double total{get;}
    private List<Inventory> products {get;}
   
    public Order(User customer, Store store, string time = ""){
        this.store = store;
        this.customer = customer;
        total = 0;
        if(time != ""){
            try{
                this.time = DateTime.ParseExact(time, "yyyy-MM-dd HH:mm:ss,fff",  System.Globalization.CultureInfo.InvariantCulture);
            }catch(FormatException){
                throw;
            }
        }else{
            this.time = DateTime.Now;
        }
    }
    
    public void addProducts(Item item, int quantity = 1){
        if(item.exists){
            if(products.contains(item)){
                products[item] += quantity;
                total += (item.price * quantity);
            }
            else{
                products.add(new Inventory(item, quantity));
                total += (item.price * quantity);
            }
        }

   }
}
}