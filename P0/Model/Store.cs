using System;
using System.Collections;
using P0Context;
using System.Linq;

namespace Model{
    public class Store{

        public string name {get; set;}
        public string location{get; set;}

        public int id {get; set; }

        private readonly ShopperContext _context;
        public  Store() { }
        public  Store(ShopperContext context)
        {
            this._context = context;
        }
       

        public Store(string name){
             this.name = name;
             location = "no location data given";
             id = 0;
        }

         public Store(string name, string location){
             this.name = name;
             this.location = location;
             id = 0;
         }

        public Store(string name, string location, int id)
        {
            this.name = name;
            this.location = location;
            this.id = id;
        }


    }

}