using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    public class Dividend
    {
        /// <summary>
        /// Uniquely identifies this dividend per stock payout announcement
        /// </summary>
        /// <value></value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long No { get; set; }

        /// <summary>
        /// Reference to company core information
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string SecurityCode { get; set; }

        /// <summary>
        /// Currency in which dividend amount is quoted
        /// </summary>
        [Required]
        [MaxLength(3)]
        public string Currency { get; set; }

        /// <summary>
        /// Dividend amount per stock unit
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime RecordDate { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// Reference to logs
        /// </summary>
        [Required]
        public Log Log { get; set; } // TODO: The Declaration Date should be stored in the logs
    }
}