using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models;

[NotMapped]
public class ReportedEarnings
{
    public string Code { get; set; }
    
    [ForeignKey("CompanyCode")]
    public Company Company { get; set; }

    public DateTime StatementDate { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Revenues { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Earnings { get; set; }

    [Column(TypeName = "decimal(5,4)")]
    public decimal Margin { get; set; }
}