using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace O8Query.Models
{
    /// <summary>
    /// Summary details of Financial Statement
    /// </summary>
    public class FinancialReport
    {
        public enum Periodical
        {
            [XmlEnum("1")]
            Quarterly = 1,
            [XmlEnum("2")]
            Annual = 2
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
        // [NotMapped]
        // public string Description 
        // { 
        //     get{ return string.Empty; } 
        // }

        /// <summary>
        /// Reference to company core information
        /// </summary>
        [Required]
        public Company Company { get; set; }

        /// <summary>
        /// Period reported. e.g. Quarterly, Annual
        /// </summary>
        [Required]
        public Periodical Period { get; set; }

        /// <summary>
        /// Date on which financial information is relevant
        /// </summary>
        [Required]
        [Column(TypeName = "date")]
        public DateTime StatementDate { get; set; }

        /// <summary>
        /// Reference to logs
        /// </summary>
        [Required]
        public Log Log { get; set; } // TODO: Date when report was released

        /// <summary>
        /// Whether or not report has been audited
        /// </summary>
        [Required]
        public bool IsAudited { get; set; }

        public virtual List<StatementAnalyte> Analytes { get; set; }

        public string Description()
        {
            return $"{Company.Name} {Period.ToString()} {StatementDate.Year.ToString()}";
        }
    }
}