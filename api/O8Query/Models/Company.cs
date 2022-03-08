using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    public class Company
    {
        /// <summary>
        /// Company code used by Stock Exchange
        /// </summary>
        [Key]
        [Required(ErrorMessage = "Please enter stock code")]
        [MaxLength(20)]
        public string Code { get; set; }
        
        /// <summary>
        /// Name of company that this security references
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Industry in which company plies its trade
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Industry { get; set; }

        /// <summary>
        /// Summary about the company
        /// </summary>
        [Required]
        public string About { get; set; }

        /// <summary>
        /// Total number of employees
        /// </summary>
        [Required]
        public int TotalEmployed { get; set; }

        /// <summary>
        /// Web address of wiki entry on company
        /// </summary>
        [Required]
        [MaxLength(2100)]
        public string Wiki { get; set; }

        // https://support.microsoft.com/en-us/topic/maximum-url-length-is-2-083-characters-in-internet-explorer-174e7c8a-6666-f4e0-6fd6-908b53c12246
        /// <summary>
        /// Web address of company's web site
        /// </summary>
        [Required]
        [MaxLength(2100)]
        public string WebSite { get; set; }

        /// <summary>
        /// Date when company was founded
        /// </summary>
        [Required]
        [Column(TypeName = "date")]
        public DateTime Founded { get; set; }

        [Required]
        [MaxLength(2)]
        public string CountryCode { get; set; }

        [Required]
        public DateTime Created { get; set; }
    }
}