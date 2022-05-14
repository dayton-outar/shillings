using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    public class Announcement
    {
        // Credit: https://www.getsmarteraboutmoney.ca/invest/investment-products/stocks/factors-that-can-affect-stock-prices/
        public enum AnnouncementType
        {
            /// <summary>
            /// Unclassified announcements
            /// </summary>
            General,
            /// <summary>
            /// General meeting
            /// </summary>
            Meeting,
            /// <summary>
            /// Dividends pay out
            /// </summary>
            Dividend,
            /// <summary>
            /// Fund raising. Whether it be leverage or equit financing
            /// </summary>
            Financing,
            /// <summary>
            /// Quarterly (10-Q) or Annual (10-K) Report
            /// </summary>
            Report,
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
            /// Changes in government policy
            /// </summary>
            Policy,
            /// <summary>
            /// Scandal
            /// </summary>
            Scandal,
            /// <summary>
            /// Issues specific to an industry or the economy
            /// </summary>
            Economy
        }

        /// <summary>
        /// Uniquely identifies this announcement
        /// </summary>
        /// <value></value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long No { get; set; }

        public string Content { get; set; }

        public AnnouncementType Type { get; set; }

        public Log Log { get; set; }

        public List<Company> Companies { get; set; }
    }
}