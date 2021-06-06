using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    /// <summary>
    /// Aggregate of stock trades
    /// </summary>
    [NotMapped]
    public class TotalStockTrades
    {
        /// <summary>
        /// Company information
        /// </summary>
        public Company Security { get; set; }
        
        /// <summary>
        /// Total volume of stocks traded
        /// </summary>
        public long Volume { get; set; }

        /// <summary>
        /// Opening price at the beginning of period
        /// </summary>
        public decimal OpeningPrice { get; set; }

        /// <summary>
        /// Closing price at the end of period
        /// </summary>
        public decimal ClosingPrice { get; set; }

        /// <summary>
        /// Change between opening price and closing price during period represented in percentage
        /// </summary>
        public decimal Percentage { get; set; }

        /// <summary>
        /// Opening date of these aggregates
        /// </summary>
        public DateTime Opening { get; set; }

        /// <summary>
        /// Closing date of these aggregates
        /// </summary>
        public DateTime Closing { get; set; }
    }
}