using System;
namespace P0{
    public class Item{
        
        public string name {get; set;}
        public double price{get; set;}
        public string description{get; set;}
        
        public Item(string name, double price, string description = "unavailable"){
            this.name = name;
            this.price = price;
            this.description = description;
        }
    }
    }

