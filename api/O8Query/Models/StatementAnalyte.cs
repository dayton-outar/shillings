using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    public class StatementAnalyte
    {
        [Flags]
        public enum Assay
        {
            // Income-Expense
            Revenue = 1,
            DirectExpense = 2,
            GrossProfit = 4,
            OperatingExpense = 8,
            Depreciation = 16,
            ProfitBeforeOtherIncome = 32,
            OtherExpense = 64,
            InterestExpense,
            OtherIncome = 128,
            InterestIncome = 264,
            ProfitBeforeInterestAndTaxes = 512,
            ProfitBeforeTaxes = 1024,
            Tax = 2048,
            NetProfit = 4096,

            ShareholdersProfit = 8192,
            NonControllingInterestProfit = 16384,

            BasicEarningsPerStock = 32768,

            // Asset-Liability
            CurrentAssets = 65536,
            Inventories = 131072,
            FixedAssets = 262144,
            TotalAssets = 524288,
            
            CurrentLiabilities = 1048576,
            FixedLiabilities = 2097152,
            TotalLiabilities = 4194304,

            TotalEquity = 8388608

            // Cash Flow
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

        /// <summary>
        /// Uniquely identifies this analyte
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long No { get; set; }

        /// <summary>
        /// Reference to summary of associated financial statement
        /// </summary>
        [ForeignKey("No")]
        public FinancialStatement Statement { get; set; }

        /// <summary>
        /// Value that sets the order of this analyte in the financial statement
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Description stated within report
        /// </summary>
        [Required]
        public string Description { get; set; }

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