using System;
using System.Collections;

using System.Linq;

namespace ModelsDefault
{
    /// <summary>
    /// Holds information about the store selected
    /// </summary>
    public class Store
    {
        public int admin { get; set; }
        public string name { get; set; }
        public string location { get; set; }

        public int numOrders { get; set; }
        public double total { get; set; }

        public int id { get; set; }

        public ModelsDefault.User user { get; set; }

        public Store() { }



        

    }

}