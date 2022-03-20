using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    public class StatementAnalyte
    {
        public enum StatementType
        {
            IncomeExpense,
            FinancialPosition,
            CashFlow
        }

        public enum Sectional
        {
            // Income
            // Credit: https://www.investopedia.com/terms/i/incomestatement.asp#toc-understanding-the-income-statement
            Revenue,
            Expenses,
            Gains,
            Losses,

            // Income - Profits Attributable
            ProfitShare,

            // Income - Company's Earnings per Stock Calculation
            EarningsPerStock,

            // Financial Position
            Assets,
            Liabilities,
            Equity,

            // Financial Position - Equity Attributable
            EquityShare
        }

        [Flags]
        public enum Assay
        {
            // Income-Expense
            Operating = 1,
            Direct = 2,
            Depreciation = 4,
            Impairment = 8,
            Interest = 16,
            Other = 32,
            /// <summary>
            /// Permanent reduction in the value of a company asset. It may be a fixed asset or an intangible asset.
            /// </summary>
            /// <remarks>
            /// Credit: https://www.investopedia.com/terms/i/impairment.asp
            /// </remarks>
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
            Debt = 262144,
            Intagible = 524288,
            
            /// <summary>
            /// Money available for immediate use
            /// </summary>
            Capital = 1048576,
            Retained = 2097152,
            Reserves = 4194304,
            // 8388608,
            // 2097152,
            // 4194304,
            // 8388608,
            // 16777216,
            // 33554432,
            // 67108864

            // Cash Flow
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
        public StatementType Type { get; set; }

        /// <summary>
        /// Section that this financial analyte is found: Income-Expense, Earnings per Stock, Assets, Liabilities, Equity
        /// </summary>
        [Required]
        public Sectional Section { get; set; }

        /// <summary>
        /// Another differentiator used to group items for calculations
        /// </summary>
        [Required]
        public Assay Analyte { get; set; }

        /// <summary>
        /// Amount stated within report
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
    }
}