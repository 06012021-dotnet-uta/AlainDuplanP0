using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Busy;

namespace P1.Models
{
    public class StoreBuilder
    {
        [Required(ErrorMessage = "You need a name")]
        [MaxLength(30, ErrorMessage = "Name is too long")]
        public string name { get; set; }

        [Required(ErrorMessage = "You need a Location")]
        [MaxLength(100, ErrorMessage = "Location is too long")]
        public string location { get; set; }

        public ModelsDefault.User user {get; set;}
    }
}
