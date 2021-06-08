using System;
namespace P0{
    public class Order{
        
    public Store store {get;}
    public User customer{get;}
    public DateTime time{get;}
    //public List<Dictionary<Item, int>> products;
   
    public Order(User customer, Store store, string time = ""){
        this.store = store;
        this.customer = customer;
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
    // public List<Dictionary<Item, int>> getProducts(){
    //     return products;
    // }
    // public void addProducts(Item item, int quantity = 1){
    //     if(item.exists){
    //         if(products.contains(item)){

    //         }
    //     }

    // }
}
}