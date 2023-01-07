using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;

namespace O8Query.Models
{
    /// <summary>
    /// Details of a given stock
    /// </summary>
    public class Stock
    {
        public enum StockClass
        {
            None = 0,
            Common = 1,
            Preferred = 2
        }

        /// <summary>
        /// Uniuely identifies stock
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long No { get; set; }

        /// <summary>
        /// Code given to this stock by the Stock Exchange
        /// </summary>
        [Required(ErrorMessage = "Please enter stock code")]
        [MaxLength(20)]
        public string Code { get; set; }

        /// <summary>
        /// Description of stock
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Currency in which stock is valued
        /// </summary>
        //[Required]
        [MaxLength(3)]
        public string Currency { get; set; }

        /// <summary>
        /// Stock type: <code>Common</code>, <code>Preferred</code> (or <code>None</code>)
        /// </summary>
        /// <remarks>
        /// <code>None</code> is initial state when stock is entered on record by scraper
        /// </remarks>
        public StockClass StockType { get; set; }

        /// <summary>
        /// Used when generating input parameter to database
        /// </summary>
        [GraphQLIgnore]
        [NotMapped]
        public int StockTypeInt
        {
            get { return (int)this.StockType; }
            set { this.StockType = (StockClass)value; }
        }

        /// <summary>
        /// Market in which this stock trades
        /// </summary>
        public Market Market { get; set; }

        /// <summary>
        /// Authorized Issued shares
        /// </summary>
        //[Required]
        public long? IssuedShares { get; set; }

        /// <summary>
        /// Outstanding shares
        /// </summary>
        //[Required]
        public long? OutstandingShares { get; set; }

        /// <summary>
        /// Company information that is associated with this stock
        /// </summary>
        //[Required]
        public Company Company { get; set; }

        /// <summary>
        /// Captures whether or not this stock is still listed on the Stock Exchange
        /// </summary>
        //[Required]
        public bool isListed { get; set; }

        /// <summary>
        /// Date and time when stock was recorded in this system
        /// </summary>
        [Required]
        public DateTime Created { get; set; }

        /// <summary>
        /// Market indices that are associates with this stock
        /// </summary>
        public List<MarketIndex> Indices { get; set; }
    }
}