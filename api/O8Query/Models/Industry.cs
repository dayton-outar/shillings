using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    /// <summary>
    /// Details of a particular market
    /// </summary>
    public class Industry
    {
        /// <summary>
        /// Uniquely identifies this industry
        /// </summary>
        /// <value></value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long No { get; set; }

        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Web address of wiki entry on industry
        /// </summary>
        [Required]
        [MaxLength(2100)]
        public string Wiki { get; set; }

        public List<Company> Companies { get; set; }

        public List<MarketIndex> MarketIndices { get; set; }
    }
}