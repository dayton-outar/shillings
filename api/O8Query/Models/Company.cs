using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    public class Company
    {
        [Required(ErrorMessage = "Please enter stock code")]
        public string Code { get; set; }
        
        public string Security { get; set; }
    }
}