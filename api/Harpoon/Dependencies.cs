using System.Collections.Generic;
using O8Query.Models;

namespace Harpoon;

public class Dependencies
{
    public List<StatementSectional> Sectionals { get; set; }
    public List<SectionalAnalytes> Assays { get; set; }
}