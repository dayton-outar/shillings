using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    /// <summary>
    /// Summary details of Financial Statement
    /// </summary>
    public class FinancialStatement
    {
        public enum Periodical
        {
            Quarterly,
            Annual
        }

        public enum StatementType
        {
            IncomeExpense,
            FinancialPosition,
            OwnersEquity,
            CashFlow
        }

        /// <summary>
        /// Uniquely identifies this Financial Statement
        /// </summary>
        /// <value></value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long No { get; set; }

        /// <summary>
        /// Describes this Financial Statement by using all the data points
        /// </summary>
        [NotMapped]
        public string Description 
        { 
            get{ return string.Empty; } 
        }

        /// <summary>
        /// Reference to company core information
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string CompanyCode { get; set; }

        /// <summary>
        /// Period reported. e.g. Quarterly, Annual
        /// </summary>
        [Required]
        public Periodical Period { get; set; }

        /// <summary>
        /// Type of statement: Income-Expense, Financial Position, Cash Flow, Statement of Equity
        /// </summary>
        [Required]
        public StatementType Type { get; set; }

        /// <summary>
        /// Date on which financial information is relevant
        /// </summary>
        [Required]
        [Column(TypeName = "date")]
        public DateTime StatementDate { get; set; }

        /// <summary>
        /// Whether or not report has been audited
        /// </summary>
        [Required]
        public bool IsAudited { get; set; }

        public virtual ICollection<StatementAnalyte> Analytes { get; set; }
    }
}