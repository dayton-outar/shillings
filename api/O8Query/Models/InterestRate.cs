namespace O8Query.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Risk-free rate for the provided jurisdictions
/// </summary>
public class InterestRate
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long No { get; set; }

    /// <summary>
    /// ISO code for jurisdiction
    /// </summary>
    [Required]
    [MaxLength(2)]
    public string CountryCode { get; set; }

    /// <summary>
    /// Lifetime of loans on which interest rate is determined. Term is in months.
    /// </summary>
    public int Term { get; set; }

    /// <summary>
    /// Interest rate
    /// </summary>
    [Required]
    [Column(TypeName = "decimal(5,4)")]
    public decimal Rate { get; set; }

    [Required]
    [Column(TypeName = "date")]
    public DateTime Date { get; set; }

    /// <summary>
    /// Reference to logs
    /// </summary>
    [Required]
    public Log Log { get; set; }
}