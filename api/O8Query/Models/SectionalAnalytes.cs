
using System.Collections.Generic;

namespace O8Query.Models
{
    public class SectionalAnalytes
    {
        /// <summary>
        /// Statement type
        /// </summary>
        public StatementAnalyte.Sectional Sectional { get; set; }
        /// <summary>
        /// Statement section
        /// </summary>
        public List<StatementAnalyte.Assay> Assay { get; set; }
    }
}