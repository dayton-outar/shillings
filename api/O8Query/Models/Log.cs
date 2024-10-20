using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace O8Query.Models
{
    /// <summary>
    /// Stores log details
    /// </summary>
    public class Log
    {
        /// <summary>
        /// 
        /// </summary>
        [Flags]
        public enum LogType
        {
            /// <summary>
            /// Applications announcement or issue
            /// </summary>
            Application = 1,
            /// <summary>
            /// Announcement
            /// </summary>
            Announcement = 2,
            /// <summary>
            /// Stock update
            /// </summary>
            Stock = 4,
            /// <summary>
            /// User activity
            /// </summary>
            User = 8
        }

        /// <summary>
        /// Log types
        /// </summary>
        public enum EventType
        {
            /// <summary>
            /// An information event. This indicates a significant, successful operation.
            /// </summary>
            Information = 0,
            /// <summary>
            /// An error event. This indicates a significant problem the user should know about; usually a loss of functionality or data.
            /// </summary>
            Warning = 1,
            /// <summary>
            /// A warning event. This indicates a problem that is not immediately significant, but that may signify conditions that could cause future problems.
            /// </summary>
            Error = 2
        }

        /// <summary>
        /// Uniuely identifies log
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long No { get; set; }

        /// <summary>
        /// Type of event logged
        /// </summary>
        [Required]
        public LogType Type { get; set; }
        
        /// <summary>
        /// Critical level of event logged
        /// </summary>
        [Required]
        public EventType Event { get; set; }

        /// <summary>
        /// Contains summary details of information logged
        /// </summary>
        [Required]
        public string Details { get; set; }

        /// <summary>
        /// Date and time event was logged
        /// </summary>
        [Required]
        public DateTime Logged { get; set; }
    }
}