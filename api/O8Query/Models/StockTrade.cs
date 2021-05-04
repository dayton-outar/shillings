using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    public class StockTrading
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long No { get; set; }

        [ForeignKey("LogNo")]
        public virtual Log Log { get; set; }

        [ForeignKey("SecurityCode")]
        public Company Security { get; set; }
        
        [Required]
        public long Volume { get; set; }

        [Required]
        public decimal ClosingPrice { get; set; }

        [Required]
        public decimal PriceChange { get; set; }

        [Required]
        public decimal Percentage { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}