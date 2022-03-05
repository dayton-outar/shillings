using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    /// <summary>
    /// Details of a particular market
    /// </summary>
    public class Market
    {
        [Key]
        [Required(ErrorMessage = "Please enter index code for market")]
        [MaxLength(20)]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Information on organization running this market
        /// </summary>
        [Required]
        public Company Company { get; set; }
    }
}