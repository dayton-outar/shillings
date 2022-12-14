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

        [Key]
        [Required(ErrorMessage = "Please enter stock code")]
        [MaxLength(20)]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Currency in which stock is valued
        /// </summary>
        //[Required]
        [MaxLength(3)]
        public string Currency { get; set; }

        /// <summary>
        /// Stock type: ORDINARY, PREFERRED, etc.
        /// </summary>
        public StockClass StockType { get; set; }

        [GraphQLIgnore]
        [NotMapped]
        public int StockTypeInt
        {
            get { return (int)this.StockType; }
            set { this.StockType = (StockClass)value; }
        }

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

        [Required]
        public DateTime Created { get; set; }

        public List<MarketIndex> Indices { get; set; }
    }
}