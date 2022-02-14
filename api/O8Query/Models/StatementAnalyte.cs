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
            OwnersEquity,
            CashFlow
        }

        public enum Sectional
        {
            Income,
            ProfitAttributable,
            EarningsPerStock,
            Assets,
            Liabilities,
            Equity,
            EquityAttributable
        }

        [Flags]
        public enum Assay
        {
            // Income-Expense
            Revenue = 1,
            DirectExpense = 2,
            GrossProfit = 4,
            OperatingExpense = 8,
            Depreciation = 16,
            Total = 32,
            Expense = 64,
            Income = 128,
            Interest = 264,
            ProfitBeforeInterest = 512,
            ProfitBeforeTaxes = 1024,
            Tax = 2048,
            NetProfit = 4096,

            ShareholdersProfit = 8192,
            NonControllingInterestProfit = 16384,

            BasicEarningsPerStock = 32768,

            // Asset-Liability
            Assets = 65536,
            Inventories = 131072,
            CurrentAssets = 262144,
            FixedAssets = 524288,
            Intagible = 1048576,
            
            Liabilities = 2097152,
            CurrentLiabilities = 4194304,
            FixedLiabilities = 8388608,

            Equity = 16777216,

            NonControllingEquity = 33554432, // 25th

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