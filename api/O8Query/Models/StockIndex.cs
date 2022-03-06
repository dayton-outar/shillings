using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    /// <summary>
    /// Details of daily summary of stock trades
    /// </summary>
    public class StockIndex
    {
        /// <summary>
        /// Uniquely identifies this daily stock index
        /// </summary>
        /// <value></value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long No { get; set; }

        [Required]
        public MarketIndex MarketIndex { get; set; }

        /// <summary>
        /// Value of index
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }

        /// <summary>
        /// Difference between opening value and closing value of index for the day
        /// </summary>
        /// <value></value>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValueChange { get; set; }

        /// <summary>
        /// Reference to logs
        /// </summary>
        [ForeignKey("LogNo")]
        public Log Log { get; set; }
    }
}