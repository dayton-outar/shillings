using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    public class Announcement
    {
        // Credit: https://www.getsmarteraboutmoney.ca/invest/investment-products/stocks/factors-that-can-affect-stock-prices/
        public enum Type
        {
            /// <summary>
            /// General meeting
            /// </summary>
            Meeting,
            /// <summary>
            /// Dividends pay out
            /// </summary>
            Dividend,
            /// <summary>
            /// Quarterly (10-Q) or Annual (10-K) Report
            /// </summary>
            FinancialReport,
            /// <summary>
            /// Merger and acquisition
            /// </summary>
            Acquisition,
            /// <summary>
            /// Change of management
            /// </summary>
            Management,
            /// <summary>
            /// Organization restructuring; employee layoffs
            /// </summary>
            Restructuring,
            /// <summary>
            /// New product, product failure or product recall
            /// </summary>
            Product,
            /// <summary>
            /// Scandal
            /// </summary>
            Scandal
        }

        /// <summary>
        /// Uniquely identifies this announcement
        /// </summary>
        /// <value></value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long No { get; set; }

        public string Content { get; set; }

        public Log Log { get; set; }
    }
}