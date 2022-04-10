
using System.Collections.Generic;

namespace O8Query.Models
{
    public class StatementSectional
    {
        /// <summary>
        /// Title of summary item
        /// </summary>
        public string SummaryTitle { get; set; }
        /// <summary>
        /// Statement type
        /// </summary>
        public StatementAnalyte.StatementType Type { get; set; }
        /// <summary>
        /// Statement section
        /// </summary>
        public List<StatementAnalyte.Sectional> Sections { get; set; }
    }
}