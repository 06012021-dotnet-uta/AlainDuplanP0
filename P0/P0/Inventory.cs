using System;
using System.Collections;

namespace P0{
    public class Inventory{
        
        public Item item {get; set;}
        public int quantity{get; set;}
        
        public Inventory(Item item, int quantity = 1){
            this.item = item;
            this. quantity = quantity;
        }
        
        
    }
    }
