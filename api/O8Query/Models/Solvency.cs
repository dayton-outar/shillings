using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models;

[NotMapped]
public class Solvency
{
    public string Code { get; set; }
    
    [ForeignKey("CompanyCode")]
    public Company Company { get; set; }

    public DateTime StatementDate { get; set; }

    /// <summary>
    /// Total Assets
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal Assets { get; set; }

    /// <summary>
    /// Working Capital
    /// </summary>
    [Column(TypeName = "decimal(5,4)")]
    public decimal Current { get; set; }

    /// <summary>
    /// Debt-to-Equity Ratio
    /// </summary>
    [Column(TypeName = "decimal(5,4)")]
    public decimal Debt { get; set; }
}