using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    public class Company
    {
        [Key]
        [Required(ErrorMessage = "Please enter stock code")]
        [MaxLength(20)]
        public string Code { get; set; }
        
        [Required]
        public string Security { get; set; }

        [Required]
        public DateTime Created { get; set; }

        //[ForeignKey("SecurityCode")]
        //public virtual ICollection<StockTrading> StockTradings { get; set; }
    }
}