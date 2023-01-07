using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class DataSource
{
    public enum Source
    {
        /// <summary>
        /// Prices of stocks traded
        /// </summary>
        StockPrices = 1,
        /// <summary>
        /// Value changes of indices of stocks
        /// </summary>
        StockIndices = 2,
        /// <summary>
        /// 
        /// </summary>
        StockDividends = 3
    }

    /// <summary>
    /// Uniquely identifies this industry
    /// </summary>
    /// <value></value>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long No { get; set; }

    /// <summary>
    /// Name that describes this data source and reader
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    public Source SourceType { get; set; }

    /// <summary>
    /// Endpoint from which data must be retrieved
    /// </summary>
    [Required]
    [MaxLength(2100)]
    public string Endpoint { get; set; }

    /// <summary>
    /// JavaScript code used by Node.js scheduled job to read data.
    /// </summary>
    [Required]
    public string Reader { get; set; }
}