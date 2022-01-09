using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    public class Company
    {
        /// <summary>
        /// Company code used by Stock Exchange
        /// </summary>
        [Key]
        [Required(ErrorMessage = "Please enter stock code")]
        [MaxLength(20)]
        public string Code { get; set; }
        
        /// <summary>
        /// Name of company that this security references
        /// </summary>
        [Required]
        public string Security { get; set; }

        /// <summary>
        /// Currency in which stock is valued
        /// </summary>
        [Required]
        [MaxLength(3)]
        public string Currency { get; set; }

        /// <summary>
        /// Industry in which company plies its trade
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Industry { get; set; }

        /// <summary>
        /// Stock type: ORDINARY, PREFERRED, etc.
        /// </summary>
        [MaxLength(50)]
        public string StockType { get; set; }

        /// <summary>
        /// Outstanding shares
        /// </summary>
        [Required]
        public int OutstandingShares { get; set; }

        /// <summary>
        /// Captures whether or not this stock is still listed on the Stock Exchange
        /// </summary>
        [Required]
        public bool isListed { get; set; }

        [Required]
        public DateTime Created { get; set; }

        //[ForeignKey("SecurityCode")]
        //public virtual ICollection<StockTrading> StockTradings { get; set; }
    }
}