using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    /// <summary>
    /// Details of daily summary of stock trades
    /// </summary>
    public class MarketIndex
    {
        /// <summary>
        /// Uniquely identifies this daily stock index
        /// </summary>
        /// <value></value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long No { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Market Market { get; set; }

        public List<Stock> Stocks { get; set; }

    }
}