using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    /// <summary>
    /// Aggregate of stock trades
    /// </summary>
    [NotMapped]
    public class TotalStockTrades
    {
        private string _pricesXml = string.Empty;

        /// <summary>
        /// Company code for stock
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Company name associated with stock
        /// </summary>
        public string Security { get; set; }
        
        /// <summary>
        /// Total volume of stocks traded
        /// </summary>
        public long Volume { get; set; }

        /// <summary>
        /// Opening price at the beginning of period
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal OpeningPrice { get; set; }

        /// <summary>
        /// Closing price at the end of period
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal ClosingPrice { get; set; }

        /// <summary>
        /// Change between opening price and closing price during period represented in percentage
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal Percentage { get; set; }

        /// <summary>
        /// Opening date of these aggregates
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime OpeningDate { get; set; }

        /// <summary>
        /// Closing date of these aggregates
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime ClosingDate { get; set; }
        
        /// <summary>
        /// XML containing list of closing prices and dates between the opening and closing dates
        /// </summary>
        [Column(TypeName = "xml")]
        public string Prices { get; set; }
    }
}