using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class DataSource
{
    /// <summary>
    /// Uniquely identifies this industry
    /// </summary>
    /// <value></value>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long No { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(2100)]
    public string Endpoint { get; set; }

    [Required]
    public string Reader { get; set; }
}