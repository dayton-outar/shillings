using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    public class StockTrading
    {
        [Required(ErrorMessage = "Please enter stock code")]
        public string Code { get; set; }
        
        public long Volume { get; set; }

        public decimal ClosingPrice { get; set; }

        public decimal PriceChange { get; set; }

        public decimal Percentage { get; set; }
    }
}