using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    /// <summary>
    /// Details of daily summary of stock trades
    /// </summary>
    public class StockTrading
    {
        /// <summary>
        /// Uniquely identifies this daily stock trade summary
        /// </summary>
        /// <value></value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long No { get; set; }

        /// <summary>
        /// Reference to logs
        /// </summary>
        [ForeignKey("LogNo")]
        public Log Log { get; set; }

        /// <summary>
        /// Company information
        /// </summary>
        [ForeignKey("SecurityCode")]
        public Company Security { get; set; }
        
        /// <summary>
        /// Total volume of stocks traded
        /// </summary>
        [Required]
        public long Volume { get; set; }

        /// <summary>
        /// Opening price at the beginning of period
        /// </summary>
        [NotMapped]
        public decimal OpeningPrice {
            get {
                return (this.ClosingPrice - this.OpeningPrice);
            }
        }

        /// <summary>
        /// Opening price at the beginning of period
        /// </summary>
        [Required]
        public decimal ClosingPrice { get; set; }

        /// <summary>
        /// Monetary value of the difference between opening price and closing price for the day
        /// </summary>
        /// <value></value>
        [Required]
        public decimal PriceChange { get; set; }

        /// <summary>
        /// Change between opening price and closing price during period represented in percentage
        /// </summary>
        [Required]
        public decimal Percentage { get; set; }

        /// <summary>
        /// Date of daily summary of stock trades
        /// </summary>
        [Required]
        public DateTime Date { get; set; }
    }
}