using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;

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

        /// <summary>
        /// Name that describes this index
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Code used by Stock Exchange to classify index
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }

        /// <summary>
        /// Market in which this index is created
        /// </summary>
        [Required]
        public Market Market { get; set; }

        /// <summary>
        /// List of stocks in this index
        /// </summary>
        [GraphQLIgnore]
        public List<Stock> Stocks { get; set; }        
        
        /// <summary>
        /// List of industries associated with stocks in this index portfolio
        /// </summary>
        public List<Industry> Industries { get; set; }
    }
}