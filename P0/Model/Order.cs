using System;
using System.Collections;
using Microsoft.Extensions.DependencyInjection;


namespace Model { 
    public class Order{
        
    public int store { get; set; }
    public User customer{ get; set; }
    public DateTime time{get;}
    
    public int id { get; set; }
    //public double total{ get; set; }
    private ArrayList products = new ArrayList();
       
   
    public Order(User customer, int store, string time = ""){
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
    
    public Order()
        {
            store = 0;
            customer = null;
            
            time = DateTime.Now;

        }

    public void addItem(Inventory item)
        {
            products.Add(item);
        }
    public ArrayList getOrder()
        {
            return products;
        }
    public double getTotal()
        {
          double all = 0;
            foreach(Inventory i in products)
            {
                all += i.total;
            }
            return all;
        }
}
}