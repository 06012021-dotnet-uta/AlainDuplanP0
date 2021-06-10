using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace RpsDBContext
{
   public partial class PlayerDerivedClass {

        public PlayerDerivedClass()
        { }
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int choice { get; set; }
        public int wins { get; set; }

        public int gameWins { get; set; }

        public int? myAge { get; set; }
        

    }
}
