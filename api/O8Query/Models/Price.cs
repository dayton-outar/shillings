using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace O8Query.Models
{
    [NotMapped]
    [XmlRoot("Prices")]
    public class Prices: List<Price> {}
    
    [NotMapped]
    public class Price
    {
        /// <summary>
        /// Company code for stock
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Company name associated with stock
        /// </summary>
        public string Security { get; set; }
        /// <summary>
        /// Closing price at the end of period
        /// </summary>
        public decimal ClosingPrice { get; set; }
        /// <summary>
        /// Date of trade
        /// </summary>
        public DateTime Date { get; set; }
    }
}