using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Busy;

namespace P1.Models
{
    public class User
    {
        

        [Required(ErrorMessage = "You need a first name")]
        [MaxLength(30, ErrorMessage = "Name is too long")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "You need a first name")]
        [MaxLength(30, ErrorMessage = "Name is too long")]
        public string Lname { get; set; }
        
        //[Required(AllowEmptyStrings =true)]
        [Range(1000,1099)]
        [DefaultValue(1000)]
        public int top { get; set; }
    }
}

