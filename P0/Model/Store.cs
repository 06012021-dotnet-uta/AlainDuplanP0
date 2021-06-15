using System;
using System.Collections;
using P0Context;
using System.Linq;

namespace Model{
    /// <summary>
    /// Holds information about the store selected
    /// </summary>
    public class Store{

        public string name {get; set;}
        public string location{get; set;}

        public int id {get; set; }

       
        public  Store() { }
       
       

        public Store(string name, string location, int id)
        {
            this.name = name;
            this.location = location;
            this.id = id;
        }
        public Store(string name, string location)
        {
            this.name = name;
            this.location = location;
            this.id = 0;
        }

    }

}