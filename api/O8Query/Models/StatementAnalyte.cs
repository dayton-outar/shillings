using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using HotChocolate;

namespace O8Query.Models
{
    public class StatementAnalyte
    {
        public enum StatementType
        {
            Income = 1,
            FinancialPosition = 2,
            CashFlow = 3
        }

        public enum Sectional
        {
            None = 0,
            // Income
            // Credit: https://www.investopedia.com/terms/i/incomestatement.asp#toc-understanding-the-income-statement
            Revenues = 1,
            Expenses = 2,
            Gains = 3,
            Losses = 4,

            // Income - Profits Attributable
            ProfitShare = 5,

            // Income - Company's Earnings per Stock Calculation
            EarningsPerStock = 6,

            /// <summary>
            /// Items describing shares outstanding
            /// </summary>
            SharesOutstanding = 7,

            // Financial Position
            Assets = 8,
            Liabilities = 9,
            Equity = 10,

            // Cash Flows
            OperatingActivities = 11,

            FinancingActivities = 12,

            InvestingActivities = 13
        }

        [Flags]
        public enum Assay
        {
            // Income-Expense
            Operating = 1, // 2^0
            Direct = 2,
            Depreciation = 4,
            /// <summary>
            /// Permanent reduction in the value of a company asset. It may be a fixed asset or an intangible asset.
            /// </summary>
            /// <remarks>
            /// Credit: https://www.investopedia.com/terms/i/impairment.asp
            /// </remarks>
            Impairment = 8,
            Interest = 16,
            Other = 32,
            
            Investment = 64,
            Tax = 128,

            Shareholders = 256,
            NonControlling = 512,

            Basic = 1024,
            Diluted = 2048,

            // Asset-Liability
            Cash = 4096,
            Inventories =  8192,
            Receivables = 16384,
            Payables = 32768,
            Current =  65536,
            Fixed = 131072,
            Loan = 262144,
            Intangible = 524288,
            
            /// <summary>
            /// Money available for immediate use
            /// </summary>
            Capital = 1048576,
            /// <summary>
            /// Retained earnings
            /// </summary>
            Retained = 2097152,
            /// <summary>
            /// Money held in bank reserves
            /// </summary>
            Reserves = 4194304,

            // Cashflow differentiators

            /// <summary>
            /// Total dividends paid or received
            /// </summary>
            Dividends = 8388608, // 2^23
            /// <summary>
            /// Money spent on buying or selling stocks
            /// </summary>
            Shares = 16777216,
            // <summary>
            // Further classify common stocks from treasury stocks
            // </summary>
            Treasury = 33554432,
            /// <summary>
            /// Wages and salary paid out to employees
            /// </summary>
            Wages = 67108864, // 2^26
            
            // 3 left ... 27 -> 29
            
            /// <summary>
            /// More details that can be used for next period.
            /// Cane be used for stating forex conversion gains or losses,
            /// stating weighed average cost of outstanding shares and so on.
            /// <summary>
            Note = 1073741824 // 2^30 ... Max
        }

        /// <summary>
        /// Uniquely identifies this analyte
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long No { get; set; }

        /// <summary>
        /// Reference to summary of associated financial statement
        /// </summary>
        public FinancialReport Report { get; set; }

        /// <summary>
        /// Value that sets the order of this analyte in the financial statement
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Description stated within report
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        /// <summary>
        /// Type of statement: Income-Expense, Financial Position, Cash Flow, Statement of Equity
        /// </summary>
        [Required]
        [XmlIgnore]
        public StatementType Type { get; set; }

        [GraphQLIgnore]
        [NotMapped]
        [XmlElement("Type")]
        public int TypeInt
        {
            get { return (int)this.Type; }
            set { this.Type = (StatementType)value; }
        }

        /// <summary>
        /// Section that this financial analyte is found: Income-Expense, Earnings per Stock, Assets, Liabilities, Equity
        /// </summary>
        [Required]
        [XmlIgnore]
        public Sectional Section { get; set; }

        [GraphQLIgnore]
        [NotMapped]
        [XmlElement("Section")]
        public int SectionInt
        {
            get { return (int)this.Section; }
            set { this.Section = (Sectional)value; }
        }

        /// <summary>
        /// Another differentiator used to group items for calculations
        /// </summary>
        [Required]
        [XmlIgnore]
        public Assay Analyte { get; set; }

        [GraphQLIgnore]
        [NotMapped]
        [XmlElement("Analyte")]
        public int AnalyteInt
        {
            get { return (int)this.Analyte; }
            set { this.Analyte = (Assay)value; }
        }

        /// <summary>
        /// Amount stated within report
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [GraphQLIgnore]
        public List<Assay> AnalyteFlags()
        {
            return Enum.GetValues(typeof(Assay)).Cast<Assay>().Distinct().Where(t => this.Analyte.HasFlag(t)).ToList();
        }
    }
}