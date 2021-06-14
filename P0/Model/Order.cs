using System;
using System.Collections;
using Microsoft.Extensions.DependencyInjection;


namespace Model { 
    public class Order{
        
    public int store { get; set; }
    public User customer{ get; set; }
    public DateTime time{get;}
    
    public int id { get; set; }
    public double total{ get; set; }
    private ArrayList products = new ArrayList();
       
   
    public Order(User customer, int store, string time = ""){
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
    
    public Order()
        {
            store = 0;
            customer = null;
            total = 0;
            time = DateTime.Now;

        }

    public void addItem(Item item)
        {
            products.Add(item);
        }
    public ArrayList getOrder()
        {
            return products;
        }
}
}