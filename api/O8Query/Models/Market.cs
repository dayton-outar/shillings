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
        /// <summary>
        /// Uniuely identifies market
        /// </summary>
        //[Key]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long No { get; set; }
        
        /// <summary>
        /// Code used by Stock Exchange to classify markets
        /// </summary>
        [Required(ErrorMessage = "Please enter index code for market")]
        [MaxLength(20)]
        public string Code { get; set; }

        /// <summary>
        /// Name that describes the market of a given Stock Exchange
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Information on organization running this market
        /// </summary>
        [Required]
        public Company Company { get; set; }

        public DataSource Source { get; set; }
    }
}