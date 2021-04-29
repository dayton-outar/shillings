using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long No { get; set; }
        
        [Required]
        public EventType Event { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public DateTime Logged { get; set; }
    }

    /// <summary>
    /// Log types
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// Logs for successfully scraping Jamaica Stock Exchange Daily Summary
        /// </summary>
        JSE
    }
}