using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace P1.Models
{
    public class User
    {
        [Required(ErrorMessage = "You need a first name")]
        [MaxLength(30, ErrorMessage = "Name is too long")]
        public string Fname { get; set; }

        [MaxLength(30, ErrorMessage = "Name is too long")]
        public string Lname { get; set; }
        
        [Range(1000,9999)]
        [DefaultValue(0)]
        public int top { get; set; }
    }
}

